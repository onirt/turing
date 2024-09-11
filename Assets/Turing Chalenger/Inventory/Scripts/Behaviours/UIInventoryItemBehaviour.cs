using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Turing.Inventory
{
    public class UIInventoryItemBehaviour : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text countText;

        public void UpdateUI(IInventoryItem item)
        {
            nameText.text = item.Model.Name;
            countText.text = item.Count.ToString();
        }
    }
}
