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
        private Queue<InventoryItemBehaviour> _unused = new();

        private void Start()
        {
            InventoryItemBehaviour uiItem; ;
            for (int i = 0; i < _slots; i++)
            {

                uiItem = Instantiate(_inventoryItemPrefab, _root);
                uiItem.name = $"Slot_{i}";
                uiItem.SetEmpty();
                _unused.Enqueue(uiItem);
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
            Debug.Log($"[1][Collect][Item]:{item.Id} [Unused]: {_unused.Count}");
            if (_unused.Count == 0) return;

            Debug.Log($"[2][Collect][Item]:{item.Id}");
            InventoryItemBehaviour uiItem;
            if (!_items.ContainsKey(item.Id))
            {
                uiItem = _unused.Dequeue();
                Debug.Log($"[Collect][Slot]: {uiItem.name} [Item]:{item.Id}");
                _items.Add(item.Id, uiItem);
                uiItem.Collect(item);
            }
        }

        public void Delete(IInventoryItem item)
        {
            Debug.Log($"[Delete][Item]:{item.Id}");
            if (_items.ContainsKey(item.Id))
            {
                Debug.Log($"[Delete][Slot]: {_items[item.Id].name} [Item]:{item.Id}");
                _unused.Enqueue(_items[item.Id]);
                _items.Remove(item.Id);
            }
        }

        public void Use(IInventoryItem item)
        {
        }
    }
}
