using DefaultNamespace;
using Personal.InventoryPackage;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodItemCellDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _stacks;
    [SerializeField] Image _thumb;
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] Button _useButton;
    [SerializeField] Button _removeButton;

    Inventory _inventory;
    InventoryItem<FoodItemData> _inventoryFoodItem;
    
    public void Initialize(InventoryItem<FoodItemData> inventoryFoodItem, Inventory inventory)
    {
        _inventoryFoodItem = inventoryFoodItem;
        _inventory = inventory;
        _useButton.onClick.AddListener(UseItemButtonCallback);
        _removeButton.onClick.AddListener(RemoveItemCallback);
        RefreshUI();

    }
    
    void UseItemButtonCallback()
    {
        _inventoryFoodItem.Use();
        RefreshUI();
    }
    
    void RemoveItemCallback()
    {
        _inventory.Remove(_inventoryFoodItem);
        RefreshUI();
    }

    void RefreshUI()
    {

        if (_inventoryFoodItem.Stacks <= 0)
        {
            Destroy(gameObject);
            return;
        }

        _stacks.SetText(_inventoryFoodItem.Stacks.ToString());
        _thumb.sprite = _inventoryFoodItem.ItemData.Thumb;
        _name.SetText(_inventoryFoodItem.ItemData.DisplayName);
        
    }
}
