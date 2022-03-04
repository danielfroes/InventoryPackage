using System;
using System.Collections.Generic;


namespace Personal.InventoryPackage
{
    [Serializable]
    public class Inventory
    {
        public string NameId { get; }
        public event Action<AInventoryItem> OnItemAdded; 
        public event Action<AInventoryItem> OnItemRemoved;
     
        
        List<AInventoryItem> _itensList = new List<AInventoryItem>();
        
        //TODO: como serializar essas variaveis
        bool _hasFiniteCapacity = false;
        int _maxCapacity= -1;
        
        internal Inventory(string nameId)
        {
            NameId = nameId;
        }

        public bool Add(AInventoryItem item)
        {
            if (_hasFiniteCapacity && _itensList.Count >= _maxCapacity)
                return false;
            
            _itensList.Add(item);
            OnItemAdded?.Invoke(item);
            return true;
        }
        
        public void Remove(AInventoryItem item)
        {
            _itensList.Remove(item);
            OnItemRemoved?.Invoke(item);
        }
        
        public IEnumerable<T> GetItens<T>()  where T : AInventoryItem
        {
            return _itensList.FindAll( item => item is T).ConvertAll(item => item as T);
        }
    }
    
}

