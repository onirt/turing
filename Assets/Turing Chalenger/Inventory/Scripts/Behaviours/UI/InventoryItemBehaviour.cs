using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Turing.Inventory
{
    public class InventoryItemBehaviour : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _countText;
        [SerializeField] private UnityEvent OnUnuseless;
        [SerializeField] private UnityEvent OnUsefull;

        private IInventoryItem _item;

        public void Delete()
        {
            _item?.Delete();
            gameObject.SetActive(false);
        }

        public void Collect(IInventoryItem item)
        {
            _item = item;
            gameObject.SetActive(true);
            UpdateItem();
        }
        private void UpdateItem()
        {
            if (_item == null) return;

            _nameText.text = _item.Model.Name;
            _countText.text = _item.Count.ToString();
            if (_item.Count <= 0)
            {
                OnUnuseless?.Invoke();
            }
            else
            {
                OnUsefull?.Invoke();
            }
        }

        public void Use()
        {
            _item?.Use();
            UpdateItem();
        }
    }
}
