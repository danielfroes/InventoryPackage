namespace Personal.InventoryPackage
{
    public interface IInventoryPersistence
    {
        InventoryLibrarySerializedData LoadInventories();

        
        void SaveInventories(InventoryLibrarySerializedData inventoryLibrarySerializedData);
    }
}