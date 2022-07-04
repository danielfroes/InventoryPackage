using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


namespace Personal.InventoryPackage
{
    [Serializable]
    public class SerializedInventoryLibrary
    {
        [SerializeField] List<Inventory> _serializedInventories;

        internal List<Inventory> SerializedInventories => _serializedInventories;
        internal SerializedInventoryLibrary(InventoryLibrary inventoryLibrary)
        {
            _serializedInventories = inventoryLibrary.Values.ToList();
        }

        public string ToJson()
        {
            string json = JsonUtility.ToJson(this);
            return json;
        }

        public byte[] ToBinary()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, this);

            return stream.ToArray();
        }
        

        public static SerializedInventoryLibrary FromJson(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data))
                    return null;
                
                return JsonUtility.FromJson<SerializedInventoryLibrary>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }

        public static SerializedInventoryLibrary FromBinary(byte[] data)
        {
            try
            {
                if (data == null || data.Length == 0)
                    return null;

                MemoryStream stream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                stream.Write(data, 0, data.Length);
                stream.Seek(0, SeekOrigin.Begin);
                return (SerializedInventoryLibrary) formatter.Deserialize(stream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }
    }
}