using Personal.InventoryPackage;
using UnityEngine;

namespace DefaultNamespace
{
    public class InventoryServiceWrapper : MonoBehaviour
    {
        [SerializeField] ItemDatabase _itemDatabase;
        
        public static InventoryService InventoryService { get; private set;}

        void Awake()
        {
            InventoryService = new InventoryService( _itemDatabase, new DebugInventoryPersistence() );
        }
        
        
    }
}