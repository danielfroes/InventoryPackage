using Personal.InventoryPackage;
using UnityEngine;

namespace DefaultNamespace
{
    public class PickableItem : MonoBehaviour
    {
        //TODO: Eu realmente nao queria ter uma referencia forte a esse cara, o idela seria se ele fosse o nameId do item
        [SerializeField] AItemData _itemData;

        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            
            var inventory = InventoryServiceWrapper.InventoryService.GetInventory(InventoryIds.PLAYER_ID);
            
            if ( inventory.Add(_itemData) )
            {
                Destroy(gameObject);
            }
        }
    }
}