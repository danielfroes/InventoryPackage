using Personal.InventoryPackage;
using UnityEngine;

namespace DefaultNamespace
{
    public class InventoryServiceWrapper : MonoBehaviour
    {
        public static InventoryService InventoryService { get; private set;}

        void Awake()
        {
            InventoryService = new InventoryService( new DebugInventoryPersistence() );
        }
        
        
    }
}