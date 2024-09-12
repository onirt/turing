using UnityEngine;
using UnityEngine.Events;

namespace Turing.Inventory
{
    public class WeaponItemBehaviour : BaseItemBehaviour
    {
        public override void Use()
        {
            Count--;
            base.Use();
            WeaponItemModel model = (WeaponItemModel)Model;
            OnUse?.Invoke(-model.Damage);
        }

        public void Reammo(int ammo)
        {
            Count += ammo;
            UpdateItem?.Invoke();
        }
    }
}
