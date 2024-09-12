using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Turing.Inventory
{
    public class InventoryItemBehaviour : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _empty;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _countText;
        [SerializeField] private UnityEvent OnUnuseless;
        [SerializeField] private UnityEvent OnUsefull;

        private IInventoryItem _item;

        [ContextMenu("Delete")]
        public void Delete()
        {
            _item?.Delete();
            _item = null;
            SetEmpty();
        }

        [ContextMenu("Use")]
        public void Use()
        {
            _item?.Use();
            UpdateItem();
        }

        public void Collect(IInventoryItem item)
        {
            _item = item;
            _item.UpdateItem.AddListener(UpdateItem);
            SetFilled();
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

        public void SetFilled()
        {
            _empty.alpha = 1;
        }

        public void SetEmpty()
        {
            _empty.alpha = 0;
        }
    }
}
