using UnityEngine.Events;

namespace Turing.Inventory
{
    public interface IInventoryItem
    {
        BaseItemModel Model { get; }

        int Id { get; }
        int Count { get; set; }

        void Use();
        void Collect();
        void Delete();
        void Restart();
    }
}
