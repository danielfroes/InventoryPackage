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
        //Isso eh uma gambiarra ne ?
        const string PLAYER_INVENTORY_ID = "Player";

        
        [SerializeField] FoodItemCellDisplay _foodItemCellPrefab;
        [SerializeField] RectTransform _itemCellsViewport;
        [SerializeField] Button _saveInventoryButton;


        List<GameObject> _instantiatedCells = new List<GameObject>();
        
        void Start()
        {
            _saveInventoryButton.onClick.AddListener(() => InventoryServiceWrapper.InventoryService.SaveInventories());
        }
        
        
        GameObject CreateFoodItemCell(FoodItem item)
        {
            var itemCell = Instantiate(_foodItemCellPrefab, _itemCellsViewport);
            itemCell.PopulateCell(item);
            itemCell.SetRemoveButtonCallback(() => RemoveItemCallback(item, itemCell));
            return itemCell.gameObject;
        }

        void RemoveItemCallback(AInventoryItem itemData, [NotNull] FoodItemCellDisplay foodItemCell)
        {
            if (foodItemCell == null) throw new ArgumentNullException(nameof(foodItemCell));
            Destroy(foodItemCell.gameObject);
            
            Inventory inventory = InventoryServiceWrapper.InventoryService.GetInventory(PLAYER_INVENTORY_ID);
            inventory.Remove(itemData);
        }


        public void Activate()
        {
            PopulateInventoryUI();
            gameObject.SetActive(true);
        }

        void PopulateInventoryUI()
        {
            Inventory inventory = InventoryServiceWrapper.InventoryService.GetInventory(PLAYER_INVENTORY_ID);
            
            foreach (FoodItem item in inventory.GetItens<FoodItem>())
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