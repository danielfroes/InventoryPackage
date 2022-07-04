using DefaultNamespace;

namespace Personal.InventoryPackage
{
    public class InventoryService
    {
        readonly InventoryLibrary _inventoryLibrary;
        readonly IInventoryPersistence _inventoryPersistence;

        readonly ItemDatabase _itemDatabase;
        
        public InventoryService(ItemDatabase itemDatabase, IInventoryPersistence inventoryPersistence = null)
        {
            _inventoryPersistence = inventoryPersistence ?? new DefaultInventoryPersistence();

            _itemDatabase = itemDatabase;
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
        
        InventoryLibrary LoadInventoryLibrary()
        {
            SerializedInventoryLibrary serializedInventoryLibrary = _inventoryPersistence.LoadInventories();
            return new InventoryLibrary(serializedInventoryLibrary, _itemDatabase);
        }

        //TODO: Remover isso aqui para a janela de criacao e gerenciamento
        Inventory CreateBlankInventory(string nameId)
        {
            Inventory blankInventory = new Inventory(nameId);
            blankInventory.SetItemDatabase(_itemDatabase);
            _inventoryLibrary.Add(nameId, blankInventory);
            return blankInventory;
        }
        
        public void SaveInventories()
        { 
            SerializedInventoryLibrary serializedInventoryLibrary = 
                new SerializedInventoryLibrary(_inventoryLibrary);
            _inventoryPersistence.SaveInventories(serializedInventoryLibrary);
        }
        
    }
}


