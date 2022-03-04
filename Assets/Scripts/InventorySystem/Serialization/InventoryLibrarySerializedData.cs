using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


namespace Personal.InventoryPackage
{
    [Serializable]
    public struct InventoryLibrarySerializedData
    {
        [SerializeField] List<InventorySerializedData> _serializedInventories;

        public List<InventorySerializedData> SerializedInventories => _serializedInventories;

        public InventoryLibrarySerializedData(IEnumerable<Inventory> inventories)
        {
            _serializedInventories = new List<InventorySerializedData>();

            foreach (var inventory in inventories)
            {
                _serializedInventories.Add(new InventorySerializedData(inventory));
            }
        }

        public string ToJson()
        {
            var json = JsonUtility.ToJson(this);

            return json;
        }

        public byte[] ToBinary()
        {
            var formatter = new BinaryFormatter();

            var stream = new MemoryStream();
            formatter.Serialize(stream, this);

            return stream.ToArray();
        }

        public IEnumerable<Inventory> GetInventory()
        {
            //criar os inventarios apartir do serializedInventories
            var inventories = new List<Inventory>();
            

            
            // foreach (var serializedInventory in _serializedInventories)
            // {
            //     foreach (ItemSerializedData serializedItem in serializedInventory.SerializedItens)
            //     {
            //       
            //     }
            //     
            //     var inventory = new Inventory(serializedInventory.NameId);
            //     
            // }

            return inventories;
        }
    }
}