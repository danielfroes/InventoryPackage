using System;
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
    public void PopulateCell(InventoryItem<FoodItemData> inventoryFoodItem)
    {
        _stacks.SetText(inventoryFoodItem.Stacks.ToString());
        _thumb.sprite = inventoryFoodItem.ItemData.Thumb;
        _name.SetText(inventoryFoodItem.ItemData.DisplayName);
        _useButton.onClick.AddListener(inventoryFoodItem.ItemData.Use);
        
    }

    public void SetRemoveButtonCallback(Action callback)
    {
        _removeButton.onClick.AddListener(callback.Invoke);
    }
}
