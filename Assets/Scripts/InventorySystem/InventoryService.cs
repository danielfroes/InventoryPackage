using System.Collections.Generic;

namespace Personal.InventoryPackage
{
    public class InventoryService
    {
        readonly InventoryLibrary _inventoryLibrary;

        readonly IInventoryPersistence _inventoryPersistence;
        
        public InventoryService(IInventoryPersistence inventoryPersistence)
        {
            _inventoryPersistence = inventoryPersistence;

            _inventoryLibrary = LoadInventoryLibrary();
        }
        
        public Inventory GetInventory(string nameId)
        {
            if (_inventoryLibrary.ContainsKey(nameId))
            {
               return _inventoryLibrary[nameId]; 
            }
            
            
            return CreateBlankInventory(nameId);
        }
        
        //talvez transformar em async
        InventoryLibrary LoadInventoryLibrary()
        {
            InventoryLibrarySerializedData serializedInventories = _inventoryPersistence.LoadInventories();
            IEnumerable<Inventory> inventories = serializedInventories.GetInventory();

            return new InventoryLibrary(inventories);
        }

        //TODO: Remover isso aqui para a janela de criacao e gerenciamento
        Inventory CreateBlankInventory(string nameId)
        {
            Inventory blankInventory = new Inventory(nameId);
            _inventoryLibrary.Add(nameId, blankInventory);
            return blankInventory;
        }
        
        public void SaveInventories()
        {
            InventoryLibrarySerializedData inventoryLibrarySerializedData = 
                new InventoryLibrarySerializedData(_inventoryLibrary.Values);
            _inventoryPersistence.SaveInventories(inventoryLibrarySerializedData);
        }
        
    }
}


