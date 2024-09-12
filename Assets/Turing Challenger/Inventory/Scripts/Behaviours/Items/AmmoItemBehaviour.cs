using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turing.Inventory
{
    public class AmmoItemBehaviour : BaseItemBehaviour
    {
        public override void Use()
        {
            base.Use();
            Count = 0;
            UpdateItem?.Invoke();
        }
    }
}
