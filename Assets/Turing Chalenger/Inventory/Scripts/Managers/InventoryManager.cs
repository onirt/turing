using System.Collections.Generic;
using UnityEngine;

namespace Turing.Inventory
{
    public class InventoryManager : MonoBehaviour, IInventory
    {
        [SerializeField] private InventoryChannel _channel;
        [SerializeField] private Transform _root;

        private Dictionary<int, InventoryItemBehaviour> _items = new();
        private Queue<InventoryItemBehaviour> _unused = new();

        private void OnEnable()
        {
            _channel.OnCollect += Collect;
            _channel.OnUse += Use;
            _channel.OnDelete += Delete;
        }

        private void OnDisable()
        {
            _channel.OnCollect -= Collect;
            _channel.OnUse -= Use;
            _channel.OnDelete -= Delete;
        }

        public void Collect(IInventoryItem item)
        {
            if (!_items.ContainsKey(item.Id))
            {
                InventoryItemBehaviour uiItem;
                if (_unused.Count > 0)
                {
                    uiItem = _unused.Dequeue();
                    uiItem.gameObject.SetActive(true);
                }
                else
                {
                    uiItem = Instantiate(item.Model.UI, _root);
                }
                uiItem.Collect(item);
                _items.Add(item.Id, uiItem);
            }
            else
            {
                _items[item.Id].Collect(item);
            }
        }

        public void Delete(IInventoryItem item)
        {
            if (_items.ContainsKey(item.Id))
            {
                _unused.Enqueue(_items[item.Id]);
                _items.Remove(item.Id);
            }
        }

        public void Use(IInventoryItem item)
        {
        }
    }
}
