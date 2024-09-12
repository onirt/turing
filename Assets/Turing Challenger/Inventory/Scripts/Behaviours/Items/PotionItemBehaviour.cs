using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Turing.Inventory
{
    public class PotionItemBehaviour : BaseItemBehaviour
    {
        public override void Use()
        {
            Count--;
            base.Use();
            PotionItemModel model = (PotionItemModel)Model;
            OnUse?.Invoke(model.Value);
        }
    }
}
