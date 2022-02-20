using Personal.InventorySystem;
using UnityEngine;


public enum PlaceholderItemCategory
{
    Potion,
    Weapon,
    Consumable
}

public class PlaceholderItem : MonoBehaviour, IInventoryItem
{
    [SerializeField] string _name;
    [SerializeField] PlaceholderItemCategory _category;
    
    public string Name => _name;
    public string Category => _category.ToString();
    public void OnAdd()
    {
        throw new System.NotImplementedException();
    }

    public void OnRemove()
    {
        throw new System.NotImplementedException();
    }

    public void Serialize()
    {
        throw new System.NotImplementedException();
    }

    public void Deserialize()
    {
        throw new System.NotImplementedException();
    }
}