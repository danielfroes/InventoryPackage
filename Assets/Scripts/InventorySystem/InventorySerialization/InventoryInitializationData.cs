using System;
using System.Collections.Generic;
using Personal.InventoryPackage;
using UnityEngine;

namespace InventorySystem.InventorySerialization
{
    [CreateAssetMenu(fileName = "new Inventory Initialization Data", menuName = "InventoryInitialization", order = 0)]
    public class InventoryInitializationData : ScriptableObject
    {

        [SerializeField] List<Inventory> _initialInventories;
    }
}