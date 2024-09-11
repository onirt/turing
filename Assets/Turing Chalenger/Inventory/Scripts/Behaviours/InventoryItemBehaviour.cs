using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace Turing.Inventory
{
    public class InventoryItemBehaviour : MonoBehaviour, IInventoryItem
    {
        [SerializeField] private InventoryItemModel model;

        [field:SerializeField] public int Count { get; set; }

        public int Id => model.Id;

        public InventoryItemModel Model => model;

        public UnityEvent<IInventoryItem> UpdateItem { get; set; }

        private void Awake()
        {
            Assert.IsNotNull(model, $"Error: No model detected on : {name}");
        }

        public virtual void Collect()
        {
            InventoryManager.Instance.Collect(this);
            UpdateItem?.Invoke(this);
        }

        public virtual void Delete()
        {
            InventoryManager.Instance.Delete(this);
            UpdateItem?.Invoke(this);
        }

        public virtual void Use()
        {
            InventoryManager.Instance.Use(this);
            UpdateItem?.Invoke(this);
        }
    }
}
