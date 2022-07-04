using System;
using System.Collections.Generic;
using UnityEngine;

namespace Personal.InventoryPackage
{
    [CreateAssetMenu(fileName = "ItemDatabase", menuName = "InventoryService/ItemDatabase")]
    public class ItemDatabase : ScriptableObject
    {
        [SerializeField] List<AItemData> _itens;

        Dictionary<string, AItemData> _itemDatabase;
            
        void OnEnable()
        {
            _itemDatabase = CreateItemDatabase();
        }

        Dictionary<string, AItemData> CreateItemDatabase()
        {
            Dictionary<string, AItemData> database = new Dictionary<string, AItemData>();
            foreach (AItemData item in _itens)
            {
                if (!database.ContainsKey(item.Id))
                {
                    database.Add(item.Id, item);
                }
            }

            return database;
        }
        
        public AItemData GetItemData(string nameId)
        {
            if(_itemDatabase.TryGetValue(nameId, out AItemData foundItem))
            {
                return foundItem;
            }
            
            Debug.LogError("[Inventory System] Item not found in item database");
            return null;
        }
        
    }
}