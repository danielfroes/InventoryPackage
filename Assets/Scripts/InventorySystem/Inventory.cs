using System;
using System.Collections.Generic;
using UnityEngine;

namespace Personal.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        readonly List<IInventoryItem> _itensList = new List<IInventoryItem>();
        public event Action<IInventoryItem> OnItemAdded;
        public event Action<IInventoryItem> OnItemRemoved;


        [SerializeField] bool _hasFiniteCapacity = false;
        [SerializeField] int _maxCapacity= -1;
        
        
        public bool Add(IInventoryItem item)
        {
            if (_hasFiniteCapacity && _itensList.Count >= _maxCapacity)
                return false;
            
            _itensList.Add(item);
            OnItemAdded?.Invoke(item);
            return true;
        }
        
        public void Remove(IInventoryItem item)
        {
            _itensList.Remove(item);
            OnItemRemoved?.Invoke(item);
        }
        
        public IEnumerable<T> GetItens<T>()  where T : class, IInventoryItem
        {
            return _itensList.FindAll( item => item is T).ConvertAll(item => item as T);
        }
        
    }
}

