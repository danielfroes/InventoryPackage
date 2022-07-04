using System;
using System.Collections.Generic;

namespace Personal.InventoryPackage
{
    
    internal class InventoryLibrary : Dictionary<string, Inventory>
    {
        public InventoryLibrary(SerializedInventoryLibrary serializedLibrary, ItemDatabase itemDatabase)
        {
            if (serializedLibrary == null) return;
            
            List<Inventory> inventories = serializedLibrary.SerializedInventories;
            inventories.ForEach(inventory => inventory.SetItemDatabase(itemDatabase));
            
            foreach (Inventory inventory in inventories)
            {
                Add(inventory.NameId, inventory);
            }

        }
        
    }
}