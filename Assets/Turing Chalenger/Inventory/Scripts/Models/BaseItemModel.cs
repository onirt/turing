using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turing.Inventory
{
    [CreateAssetMenu(fileName = "BaseItemModel", menuName = "Turing/Models/Items/Common")]
    public class BaseItemModel : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public InventoryItemBehaviour UI { get; private set; }
    }
}
