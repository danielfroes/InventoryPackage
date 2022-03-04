using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class InputUIController : MonoBehaviour
    {
        [SerializeField] InventoryMenuController _inventoryMenu;
        [SerializeField] FirstPersonController _fpsController;
        
        bool _isEditActive;

        void Start()
        {
            _inventoryMenu.gameObject.SetActive(false);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
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
            _inventoryMenu.Deactivate();
            
            _fpsController.playerCanMove = true;
            _fpsController.cameraCanMove = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void ActivateEditMode()
        {
            _inventoryMenu.Activate();
            
            _fpsController.playerCanMove = false;
            _fpsController.cameraCanMove = false;
            Cursor.lockState = CursorLockMode.None;
        }

    }
}