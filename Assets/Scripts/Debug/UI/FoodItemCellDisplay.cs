using System;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodItemCellDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _id;
    [SerializeField] Image _thumb;
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] Button _useButton;
    [SerializeField] Button _removeButton;
    public void PopulateCell(FoodItem itemData)
    {
        _id.SetText($"{itemData.Id}" );
        _thumb.sprite = itemData.Thumb;
        _name.SetText(itemData.ItemName);
        _useButton.onClick.AddListener(itemData.Use);
        
    }

    public void SetRemoveButtonCallback(Action callback)
    {
        _removeButton.onClick.AddListener(callback.Invoke);
    }
}
