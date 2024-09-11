using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Turing.Inventory
{
    public interface IInventoryItem: IInventory
    {
        int Count { get; set; }
        int Id { get; }
        InventoryItemModel Model { get; }
        UnityEvent<IInventoryItem> UpdateItem { get; set; }
    }
}
