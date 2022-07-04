using System;

namespace Personal.InventoryPackage
{
    public class InventoryItem<T> where T : AItemData
    {
        public readonly T ItemData;
        public  int Stacks => InventoryUnit.Stacks;
        
        internal readonly InventoryUnit InventoryUnit;

        readonly Inventory _inventory;
        
        internal InventoryItem(T itemData, InventoryUnit inventoryUnit, Inventory inventory)
        {
            ItemData = itemData;
            InventoryUnit = inventoryUnit;
            _inventory = inventory;
        }

        public void Use(params object[] args)
        {
            switch (ItemData.UseCategory)
            {
                case UseCategory.Consumable:
                    ItemData.UseItem(args);
                    _inventory.Remove(this);
                    break;
                
                case UseCategory.NonConsumable:
                    ItemData.UseItem(args);
                    break;
                
                case UseCategory.NonUsable:
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}