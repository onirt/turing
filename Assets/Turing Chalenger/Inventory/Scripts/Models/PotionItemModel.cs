using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turing.Inventory
{
    [CreateAssetMenu(fileName = "PotionItemModel", menuName = "Turing/Models/Items/Potion")]
    public class PotionItemModel : BaseItemModel
    {
        [field: SerializeField] public int Value { get; private set; }
    }
}
