using System;
using Personal.InventoryPackage;


namespace DefaultNamespace
{
    public class DebugInventoryPersistence : IInventoryPersistence
    {
        public void SaveInventories(InventoryLibrarySerializedData inventoryLibrarySerializedData)
        {
            //Debug.Log(inventorySerializedData.ToJson());
        }
        
        
        public InventoryLibrarySerializedData LoadInventories()
        {
            //throw new NotImplementedException();
            return new InventoryLibrarySerializedData();
        }

    }
    
    [Serializable]
    public struct SerializableArray
    {
        public AInventoryItem[] Array;
        public string teste ;

        public SerializableArray(AInventoryItem[] array)
        {
            Array = array;
            teste = "isso era pra funcionar";
        }
    }

    [Serializable]
    public class User
    {
        public int age = 22;
        public string name = "daniel";
    }
}