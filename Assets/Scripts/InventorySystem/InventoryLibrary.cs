using System.Collections.Generic;

namespace Personal.InventoryPackage
{
    internal class InventoryLibrary : Dictionary<string, Inventory>
    {
        public InventoryLibrary(IEnumerable<Inventory> inventories)
        {
            foreach (var inventory in inventories)
            {
                Add(inventory.NameId, inventory);
            }
        }
    }
}