using UnityEngine;

namespace Personal.InventoryPackage
{
    public enum UseCategory
    {
        Consumable,
        NonConsumable,
        Selectable,
        NonUsable
    }
    public class AInventoryItem : ScriptableObject
    {
        [SerializeField] int _id;
        [SerializeField] string _itemName;
        [SerializeField] bool _isStackable = false;
        [SerializeField] int _maxStacks = -1;
        [SerializeField] UseCategory _useCategory;

        public string ItemName => _itemName;
        public int Id => _id;
        public bool IsStackable => _isStackable;
        public int MaxStacks => _maxStacks;
        public UseCategory UseCategory => _useCategory;

        
        
        public virtual void Use(){}

        
        public ItemSerializedData Serialize()
        {
            return new ItemSerializedData();
        }

        public void Deserialize(ItemSerializedData itemSerializedData)
        {
            
        }
    }
}