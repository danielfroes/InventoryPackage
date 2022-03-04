using Personal.InventoryPackage;
using UnityEngine;

namespace DefaultNamespace
{
    public class PickableItem : MonoBehaviour
    {
        const string PLAYER_INVENTORY_ID = "Player";
        
        [SerializeField] AInventoryItem item;
        
        
        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            
            var inventory = InventoryServiceWrapper.InventoryService.GetInventory(PLAYER_INVENTORY_ID);
            
            if ( inventory.Add(item) )
            {
                Destroy(gameObject);
            }
        }
    }
}