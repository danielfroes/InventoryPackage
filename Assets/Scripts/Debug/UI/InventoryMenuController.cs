using System.Collections.Generic;
using Personal.InventoryPackage;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class InventoryMenuController : MonoBehaviour
    {
        
        [SerializeField] FoodItemCellDisplay _foodItemCellPrefab;
        [SerializeField] RectTransform _itemCellsViewport;
        [SerializeField] Button _saveInventoryButton;

        readonly List<FoodItemCellDisplay> _instantiatedCells = new List<FoodItemCellDisplay>();
        
        void Start()
        {
            _saveInventoryButton.onClick.AddListener(() => InventoryServiceWrapper.InventoryService.SaveInventories());
        }
        
        void PopulateInventoryUI()
        {
            Inventory inventory = InventoryServiceWrapper.InventoryService.GetInventory(InventoryIds.PLAYER_ID);
            
            foreach (InventoryItem<FoodItemData> inventoryFoodItem in inventory.GetItens<FoodItemData>())
            {
                FoodItemCellDisplay itemCell = Instantiate(_foodItemCellPrefab, _itemCellsViewport);
                _instantiatedCells.Add(itemCell);

                itemCell.Initialize(inventoryFoodItem, inventory);
            }
        }
        
        public void Activate()
        {
            PopulateInventoryUI();
            gameObject.SetActive(true);
        }
        
        public void Deactivate()
        {
            DeleteInstantiatedCells();
            gameObject.SetActive(false);
        }

        void DeleteInstantiatedCells()
        {
            foreach (FoodItemCellDisplay cell in _instantiatedCells)
            {
                if (cell != null)
                {
                    Destroy(cell.gameObject);
                }
            }
            _instantiatedCells.Clear();
        }
        
    }
}