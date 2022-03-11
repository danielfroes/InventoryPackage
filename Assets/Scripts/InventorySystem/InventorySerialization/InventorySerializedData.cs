using System;
using System.Collections.Generic;

namespace Personal.InventoryPackage
{
    [Serializable]
    public struct InventorySerializedData
    {
        public string NameId;
        public  List<ItemSerializedData> SerializedItens;
            
        public InventorySerializedData(Inventory inventory)
        {
            SerializedItens = new List<ItemSerializedData>();
            NameId = inventory.NameId;
                
            foreach (var item in inventory.GetItens<AItemData>())
            {
               // SerializedItens.Add(item.Serialize());
            }
        }
    }
}