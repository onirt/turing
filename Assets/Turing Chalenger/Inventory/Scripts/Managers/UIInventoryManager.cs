using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turing.Inventory
{
    public class UIInventoryManager : MonoBehaviour
    {
        [SerializeField] private Transform root;

        private void OnEnable()
        {
            var inventory = InventoryManager.Instance;
            inventory.OnCollect += Collect;
        }

        private void OnDisable()
        {
            var inventory = InventoryManager.Instance;
            inventory.OnCollect -= Collect;
        }

        public void Collect(IInventoryItem item)
        {
            var uiItem = Instantiate(item.Model.UI, root);
            item.UpdateItem.AddListener(uiItem.UpdateUI);
        }
    }
}
