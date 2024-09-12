using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Turing.Inventory
{
    [CreateAssetMenu(fileName = "InventoryChannel", menuName = "Turing/Channels/Inventoy")]
    public class InventoryChannel : ScriptableObject, IInventory
    {
        public UnityAction<IInventoryItem> OnCollect;
        public UnityAction<IInventoryItem> OnUse;
        public UnityAction<IInventoryItem> OnDelete;

        public void Collect(IInventoryItem item)
        {
            OnCollect?.Invoke(item);
        }

        public void Delete(IInventoryItem item)
        {
            OnUse?.Invoke(item);
        }

        public void Use(IInventoryItem item)
        {
            OnDelete?.Invoke(item);
        }
    }
}
