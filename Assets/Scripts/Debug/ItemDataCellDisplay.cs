using System;
using Personal.InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataCellDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _category;
    [SerializeField] Button _button;
    public void PopulateCell(PlaceholderItem itemData)
    {
        _name.SetText(itemData.Name);
        _category.SetText(itemData.Category);
    }

    public void SetRemoveButtonCallback(Action callback)
    {
        _button.onClick.AddListener(callback.Invoke);
    }
}
