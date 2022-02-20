using Personal.InventorySystem;
using UnityEngine;

public class PickupItemTrigger : MonoBehaviour
{

    [SerializeField] Inventory _inventory;
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Item")) return;
        
        var item =  other.GetComponent<PlaceholderItem>();

        if ( _inventory.Add(item) )
        {
            Destroy(other.gameObject);
        }
    }
}