using System;
using System.Collections.Generic;
using JetBrains.Annotations;
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


        List<GameObject> _instantiatedCells = new List<GameObject>();
        
        void Start()
        {
            _saveInventoryButton.onClick.AddListener(() => InventoryServiceWrapper.InventoryService.SaveInventories());
        }
        
        GameObject CreateFoodItemCell(InventoryItem<FoodItemData> inventoryFoodItem)
        {
            var itemCell = Instantiate(_foodItemCellPrefab, _itemCellsViewport);
            itemCell.PopulateCell(inventoryFoodItem);
            //itemCell.SetRemoveButtonCallback(() => RemoveItemCallback(inventoryFoodItem, itemCell));
            return itemCell.gameObject;
        }

        void RemoveItemCallback(AItemData itemDataData, [NotNull] FoodItemCellDisplay foodItemCell)
        {
            if (foodItemCell == null) throw new ArgumentNullException(nameof(foodItemCell));
            Destroy(foodItemCell.gameObject);
            
            Inventory inventory = InventoryServiceWrapper.InventoryService.GetInventory(InventoryIds.PLAYER_ID);
            //inventory.Remove(inventoryItemData);
        }


        public void Activate()
        {
            PopulateInventoryUI();
            gameObject.SetActive(true);
        }

        void PopulateInventoryUI()
        {
            Inventory inventory = InventoryServiceWrapper.InventoryService.GetInventory(InventoryIds.PLAYER_ID);
            
            foreach (InventoryItem<FoodItemData> item in inventory.GetItens<FoodItemData>())
            {
                _instantiatedCells.Add(CreateFoodItemCell(item));
            }
        }
        
        public void Deactivate()
        {
            DeleteInstantiatedCells();
            gameObject.SetActive(false);
        }

        void DeleteInstantiatedCells()
        {
            foreach (GameObject cell in _instantiatedCells)
            {
                Destroy(cell);
            }
            _instantiatedCells.Clear();
        }
        
    }
}