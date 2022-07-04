using System.IO;
using Personal.InventoryPackage;
using UnityEngine;

namespace DefaultNamespace
{
    public class DefaultInventoryPersistence : IInventoryPersistence
    {
        string FilePath => Application.persistentDataPath + "/inventory.bin";
        
        public SerializedInventoryLibrary LoadInventories()
        {
            if (File.Exists(FilePath) == false)
                return null;

            byte[] data = File.ReadAllBytes(FilePath);
            return SerializedInventoryLibrary.FromBinary(data);
        }

        public void SaveInventories(SerializedInventoryLibrary serializedInventoryLibrary)
        {
            byte[] data = serializedInventoryLibrary.ToBinary();
            File.WriteAllBytes(FilePath, data);
        }
    }
}