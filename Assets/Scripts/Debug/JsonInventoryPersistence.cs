using System.IO;
using Personal.InventoryPackage;
using UnityEngine;


namespace DefaultNamespace
{
    public class JsonInventoryPersistence : IInventoryPersistence
    {
        string FilePath => Application.persistentDataPath + "/inventory.json";

        public void SaveInventories(SerializedInventoryLibrary serializedInventoryLibrary)
        { 
            string jsonData = serializedInventoryLibrary.ToJson();
            
            using(StreamWriter writer = new StreamWriter(FilePath))
            {
                writer.Write(jsonData);
            }
            
        }

        public SerializedInventoryLibrary LoadInventories()
        {
            if (File.Exists(FilePath) == false)
                return null;
                
            using (StreamReader reader = new StreamReader(FilePath))
            {
                string jsonData = reader.ReadToEnd();
                return SerializedInventoryLibrary.FromJson(jsonData);
            }

        }

    }
}