using System;
using System.Collections.Generic;
using UnityEngine;

namespace Personal.InventoryPackage
{
    [Serializable]
    public class Inventory
    {
        public event Action<AItemData> OnItemAdded; 
        public event Action<AItemData> OnItemRemoved;

        [SerializeField] string _nameId;
        [SerializeField] List<InventoryUnit> _itemUnits = new List<InventoryUnit>();

        ItemDatabase _itemDatabase;
        
        //TODO: como serializar essas variaveis
        bool _hasFiniteCapacity = false;
        int _maxCapacity= -1;
        
        public int Count => _itemUnits.Count;
        public string NameId => _nameId;

        internal Inventory(string nameId)
        {
            _nameId = nameId;
        }

        public bool Add(AItemData itemData)
        {
            if (_hasFiniteCapacity && _itemUnits.Count >= _maxCapacity)
                return false;

            bool slotsStacksAreFull = false;
            
            if (itemData.IsStackable)
            {
                List<InventoryUnit> foundItemUnits =
                    _itemUnits.FindAll((inventoryUnit => inventoryUnit.ItemId == itemData.Id));
                
                InventoryUnit foundUnit = foundItemUnits.Find(unit =>
                    unit.Stacks < itemData.MaxStacks || itemData.MaxStacks == AItemData.INFITINY_STACKS);

                if (foundUnit != null)
                {
                    foundUnit.Stacks++;
                }
                else
                {
                    slotsStacksAreFull = true;
                }
            }
            
            if(itemData.IsStackable == false || slotsStacksAreFull )
            {
                _itemUnits.Add(new InventoryUnit(itemData.Id));
            }
            
            OnItemAdded?.Invoke(itemData);
            return true;
        }


        public bool Remove<T>(InventoryItem<T> item) where T : AItemData
        {
            InventoryUnit inventoryUnit = item.InventoryUnit;
            
            if (!_itemUnits.Contains(inventoryUnit) || inventoryUnit.Stacks <= 0)
                return false;
            
            inventoryUnit.Stacks--;
            
            if (inventoryUnit.Stacks == 0)
            {
                _itemUnits.Remove(inventoryUnit);
            }
            
            //Dar uma olhada nesso argumento aqui
            OnItemRemoved?.Invoke(item.ItemData);
            return true;
        }
     

        public IEnumerable<InventoryItem<T>> GetItens<T>()  where T : AItemData
        {
            return _itemUnits.FindAll(unit => _itemDatabase.GetItemData(unit.ItemId) is T).
                ConvertAll(unit =>
                    new InventoryItem<T>(
                        _itemDatabase.GetItemData(unit.ItemId) as T,
                        unit, 
                        this));
        }

        internal void SetItemDatabase(ItemDatabase itemDatabase)
        {
            _itemDatabase = itemDatabase;
        }
    }
    
    [Serializable]
    internal class InventoryUnit
    {
        [SerializeField] string _itemId;
        [SerializeField] int _stacks;
        public string ItemId => _itemId;
        public int Stacks
        {
            get => _stacks;
            set => _stacks = value;
        }

        public InventoryUnit(string itemId)
        {
            _itemId = itemId;
            _stacks = 1;
        }

    }
}

