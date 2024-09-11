using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Turing.Inventory
{
    public class InventoryManager
    {
		private static InventoryManager instance = null;
		private static readonly object padlock = new object();
		public static InventoryManager Instance
		{
			get
			{
				lock (padlock)
				{
					if (instance == null)
					{
						instance = new InventoryManager();
					}
					return instance;
				}
			}
		}
		private Dictionary<int, IInventoryItem> collected;
		public UnityAction<IInventoryItem> OnCollect;
		InventoryManager()
		{
			collected = new();
		}

		public void Collect(IInventoryItem item)
        {
			if (collected.ContainsKey(item.Id))
            {
				collected[item.Id].Count += item.Count;
            }
            else
            {
				collected.Add(item.Id, item);
            }
			OnCollect?.Invoke(collected[item.Id]);
        }
		public void Use(IInventoryItem item)
		{
			if (collected.ContainsKey(item.Id))
			{
				collected[item.Id].Count -= item.Count;
				if (collected[item.Id].Count <= 0)
                {
					item.Delete();
				}
			}

		}
		public void Delete(IInventoryItem item)
        {
			if (collected.ContainsKey(item.Id))
			{
				collected.Remove(item.Id);
			}
		}
	}
}
