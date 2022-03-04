using Personal.InventoryPackage;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Food", menuName = "item/Food", order = 0)]
    public class FoodItem : AInventoryItem
    {
        [SerializeField] Sprite _thumb;
        [SerializeField] PickableItem _pickableItemPrefab;

        public Sprite Thumb => _thumb;
        public PickableItem PickableItemPrefab => _pickableItemPrefab;
        
        public override void Use()
        {
            Debug.Log($"Comendo a : {ItemName}");
        }
    }
}