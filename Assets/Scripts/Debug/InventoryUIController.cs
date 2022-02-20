using System;
using JetBrains.Annotations;
using Personal.InventorySystem;
using UnityEngine;

namespace DefaultNamespace
{
    public class InventoryUIController : MonoBehaviour
    {
        [SerializeField] FirstPersonController _fpsController;
        [SerializeField] Inventory _inventory;
        [SerializeField] ItemDataCellDisplay _itemCellPrefab;
        [SerializeField] RectTransform _itemCellsViewport;
        [SerializeField] GameObject _editModePanel;
        
        bool _isEditActive = false;
        void Start()
        {
            _editModePanel.SetActive(false);
            _inventory.OnItemAdded += CreateItemCell;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _isEditActive = !_isEditActive;
                if (_isEditActive)
                {
                    ActivateEditMode();
                }
                else
                {
                    DeactivateEditMode();
                }
            }
        }

        void DeactivateEditMode()
        {
            _fpsController.playerCanMove = true;
            _fpsController.cameraCanMove = true;
            _editModePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        void ActivateEditMode()
        {
            _fpsController.playerCanMove = false;
            _fpsController.cameraCanMove = false;
            _editModePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

        void CreateItemCell(IInventoryItem itemData)
        {
            if (!(itemData is PlaceholderItem)) return;

            var placeholderItemData = (PlaceholderItem) itemData;
            
            var itemCell = Instantiate(_itemCellPrefab, _itemCellsViewport);
            
            itemCell.PopulateCell(placeholderItemData);
            itemCell.SetRemoveButtonCallback(() => DeleteCell(placeholderItemData, itemCell));

        }

        void DeleteCell(IInventoryItem itemData, [NotNull] ItemDataCellDisplay itemCell)
        {
            if (itemCell == null) throw new ArgumentNullException(nameof(itemCell));
            Destroy(itemCell.gameObject);

            _inventory.Remove(itemData);
        }

        void OnDestroy()
        {
            _inventory.OnItemAdded -= CreateItemCell;
        }
    }
}