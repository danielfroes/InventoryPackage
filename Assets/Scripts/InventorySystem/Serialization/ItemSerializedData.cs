using System;
using System.Collections.Generic;
using UnityEngine;

namespace Personal.InventoryPackage
{
    [Serializable]
    public struct ItemSerializedData
    {
        [SerializeField] List<SerializedVariable> _intVariables;
        [SerializeField] List<SerializedVariable> _floatVariables;
        [SerializeField] List<SerializedVariable> _boolVariables;
        [SerializeField] List<SerializedVariable> _stringVariables;
        
        public void AddVariable(string name, int value)
        {
            if (_intVariables == null)
            {
                _intVariables = new List<SerializedVariable>();
            }
            _intVariables.Add(new SerializedVariable(name, value.ToString()));
        }
        
        public void AddVariable(string name, float value)
        {
            if (_intVariables == null)
            {
                _floatVariables = new List<SerializedVariable>();
            }
            
            _floatVariables.Add(new SerializedVariable(name, value.ToString()));
        }
        
        public void AddVariable(string name, bool value)
        {
            if (_intVariables == null)
            {
                _boolVariables = new List<SerializedVariable>();
            }
            _boolVariables.Add(new SerializedVariable(name, value.ToString()));
        }
        
        public void AddVariable(string name, string value)
        {
            if (_stringVariables== null)
            {
                _stringVariables = new List<SerializedVariable>();
            }
            _stringVariables.Add(new SerializedVariable(name, value));
        }
        
      
        [Serializable]
        struct SerializedVariable
        {
            public string Name;
            public string Value;
            public SerializedVariable(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }

        public int GetVariable(string name)
        {
            string value = _intVariables.Find(variable => variable.Name == name).Value;
            return int.Parse(value);
        }
        
    
        
    }
}