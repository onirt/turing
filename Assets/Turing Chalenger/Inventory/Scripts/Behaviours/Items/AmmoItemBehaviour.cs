using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turing.Inventory
{
    public class AmmoItemBehaviour : BaseItemBehaviour
    {
        public override void Use()
        {
            OnUse?.Invoke(Count);
            Count = 0;
            base.Use();
        }
    }
}
