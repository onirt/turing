using System.Collections.Generic;
using UnityEngine;

namespace Turing.Inventory
{
    public class InventoryManager : MonoBehaviour, IInventory
    {
        [SerializeField] private InventoryChannel _channel;
        [SerializeField] private InventoryItemBehaviour _inventoryItemPrefab;
        [SerializeField] private Transform _root;
        [SerializeField] private int _slots = 9;

        private Dictionary<int, InventoryItemBehaviour> _items = new();
        private Stack<InventoryItemBehaviour> _unused = new();

        private void Start()
        {
            InventoryItemBehaviour uiItem; ;
            for (int i = 0; i < _slots; i++)
            {

                uiItem = Instantiate(_inventoryItemPrefab, _root);
                uiItem.SetEmpty();
                _unused.Push(uiItem);
            }
        }

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
            if (_unused.Count == 0) return;

            InventoryItemBehaviour uiItem;
            if (!_items.ContainsKey(item.Id))
            {
                uiItem = _unused.Pop();
                _items.Add(item.Id, uiItem);
            }
            else
            {
                uiItem = _items[item.Id];
            }
            uiItem.Collect(item);
        }

        public void Delete(IInventoryItem item)
        {
            if (_items.ContainsKey(item.Id))
            {
                _unused.Push(_items[item.Id]);
                _items.Remove(item.Id);
            }
        }

        public void Use(IInventoryItem item)
        {
        }
    }
}
