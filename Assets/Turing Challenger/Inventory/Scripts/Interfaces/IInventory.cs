

namespace Turing.Inventory
{
    public interface IInventory
    {
        void Collect(IInventoryItem item);
        void Use(IInventoryItem item);
        void Delete(IInventoryItem item);
    }
}
