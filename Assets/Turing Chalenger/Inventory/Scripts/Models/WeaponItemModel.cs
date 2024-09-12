using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turing.Inventory
{
    [CreateAssetMenu(fileName = "WeaponItemModel", menuName = "Turing/Models/Items/Weapon")]
    public class WeaponItemModel : BaseItemModel
    {
        [field: SerializeField] public int Damage { get; private set; }
    }
}
