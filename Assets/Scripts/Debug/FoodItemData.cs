using Personal.InventoryPackage;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Food", menuName = "Itens/Food", order = 0)]
    public class FoodItemData : AItemData
    {
        [SerializeField] string _displayName;
        [SerializeField] Sprite _thumb;
        [SerializeField] PickableItem _pickableItemPrefab;

        public string DisplayName => _displayName;
        public Sprite Thumb => _thumb;
        public PickableItem PickableItemPrefab => _pickableItemPrefab;
        
        protected override void OnUse(params object[] args)
        {
            Debug.Log($"Comendo a : {Id}");
        }
    }
}