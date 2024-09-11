using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turing.Inventory
{
    [CreateAssetMenu(fileName = "InventoryItemModel", menuName = "Turing/Models/Inventory/Item")]
    public class InventoryItemModel : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public UIInventoryItemBehaviour UI { get; private set; }
    }
}
