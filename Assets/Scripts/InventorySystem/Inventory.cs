using System;
using System.Collections.Generic;

namespace Personal.InventoryPackage
{
    [Serializable]
    public class Inventory
    {
        public string NameId { get; }
        public event Action<AItemData> OnItemAdded; 
        public event Action<AItemData> OnItemRemoved;

        List<InventoryUnit> _itemUnits = new List<InventoryUnit>();

        ItemDatabase _itemDatabase;
        
        //TODO: como serializar essas variaveis
        bool _hasFiniteCapacity = false;
        int _maxCapacity= -1;
        
        public int Count => _itemUnits.Count;

        internal Inventory(string nameId, ItemDatabase itemDatabase)
        {
            _itemDatabase = itemDatabase;
            
            NameId = nameId;
        }

        public bool Add(AItemData itemData)
        {
            if (_hasFiniteCapacity && _itemUnits.Count >= _maxCapacity)
                return false;
            
            AddItem(itemData);
            
            OnItemAdded?.Invoke(itemData);
            return true;
        }

        void AddItem(AItemData itemData)
        {
            if (itemData.IsStackable)
            {
                List<InventoryUnit> foundItemUnits =
                    _itemUnits.FindAll((inventoryUnit => inventoryUnit.ItemId == itemData.Id));
                
                foreach (InventoryUnit itemUnit in foundItemUnits)
                {
                    if (itemUnit.Stacks < itemData.MaxStacks || itemData.MaxStacks == AItemData.INFITINY_STACKS)
                    {
                        itemUnit.Stacks += 1;
                        return;
                    }
                }
            }
          
            _itemUnits.Add(new InventoryUnit(itemData.Id));
        }
        

        // public bool Remove(AInventoryItem item)
        // {
        //     if (!_itemUnits.Exists(itemUnit => itemUnit.item == item))
        //         return false;
        //
        //     RemoveItem(item);
        //     OnItemRemoved?.Invoke(item);
        //     return true;
        // }
        //
        // void RemoveItem(InventoryItemUnit item)
        // {
        //     List<InventoryItemUnit> foundItemUnits =
        //             _itemUnits.FindAll((inventoryUnit => inventoryUnit.item == item));
        //
        //     foreach (InventoryItemUnit itemUnit in foundItemUnits)
        //     {
        //         itemUnit.Stacks--;
        //     }
        //     
        // }


        public IEnumerable<InventoryItem<T>> GetItens<T>()  where T : AItemData
        {
            return _itemUnits.
                FindAll(inventoryUnit => _itemDatabase.GetItemData(inventoryUnit.ItemId) is T).
                ConvertAll(inventoryUnit => 
                    new InventoryItem<T>(
                        _itemDatabase.GetItemData(inventoryUnit.ItemId) as T,
                        inventoryUnit.Stacks));
        }
        
        
        class InventoryUnit
        {
            public readonly string ItemId;
            public int Stacks;
        
            public InventoryUnit(string itemId)
            {
                ItemId = itemId;
                Stacks = 1;
            }

        }
        
    }


    public readonly struct InventoryItem<T> where T : AItemData
    {
        public readonly T ItemData;
        public readonly int Stacks;
        
        public InventoryItem(T itemData, int stacks)
        {
            ItemData = itemData;
            Stacks = stacks;
        }
    }


    
}

