using UnityEngine;
using UnityEngine.Events;

namespace Turing.Inventory
{
    public interface IInventoryItem: IPositioner
    {
        BaseItemModel Model { get; }

        int Id { get; }
        int Count { get; set; }

        void Use();
        void Collect();
        void Delete();
        void Restart();

        UnityEvent UpdateItem { get; set; }
    }

    public interface IPositioner
    {
        Vector3 GetPostion();
    }
}
