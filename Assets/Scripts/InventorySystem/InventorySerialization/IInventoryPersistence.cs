namespace Personal.InventoryPackage
{
    public interface IInventoryPersistence
    {
        SerializedInventoryLibrary LoadInventories();
        void SaveInventories(SerializedInventoryLibrary serializedInventoryLibrary);
    }
}