using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turing
{
    public interface IInventory
    {
        void Use();
        void Collect();
        void Delete();
    }
}
