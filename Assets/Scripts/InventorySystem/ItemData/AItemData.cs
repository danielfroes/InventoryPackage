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
    public class AItemData : ScriptableObject
    {
        public const int INFITINY_STACKS = -1;
        
        [SerializeField] string _id;
        [SerializeField] bool _isStackable = false;
        [SerializeField] int _maxStacks = INFITINY_STACKS;
        [SerializeField] UseCategory _useCategory;

        public string Id => _id;
        public bool IsStackable => _isStackable;
        public int MaxStacks => _maxStacks;
        public UseCategory UseCategory => _useCategory;
        
        public virtual void Use(){}
        
    }
}