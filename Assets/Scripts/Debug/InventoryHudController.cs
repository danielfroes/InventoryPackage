using DefaultNamespace;
using Personal.InventoryPackage;
using TMPro;
using UnityEngine;

public class InventoryHudController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _inventoryCount;

    Inventory _playerInventory;
    
    void Start()
    {
        _playerInventory = InventoryServiceWrapper.InventoryService.GetInventory(InventoryIds.PLAYER_ID);
        RefreshInventoryCountHud();
        
        _playerInventory.OnItemAdded += _ => RefreshInventoryCountHud();
        _playerInventory.OnItemRemoved += _ => RefreshInventoryCountHud();
        
        
    }

    void RefreshInventoryCountHud()
    {
        _inventoryCount.SetText(_playerInventory.Count.ToString("00"));
    }


}
