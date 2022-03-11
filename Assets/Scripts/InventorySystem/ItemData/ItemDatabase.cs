using System.Collections.Generic;
using UnityEngine;

namespace Personal.InventoryPackage
{
    [CreateAssetMenu(fileName = "ItemDatabase", menuName = "InventoryService/ItemDatabase")]
    public class ItemDatabase : ScriptableObject
    {
        [SerializeField] List<AItemData> _itens;
        
        
        //TODO: talvez cirar um dicionario ou usar um dicionario serializado se pa ou talvez usar o System.Guid para criar o id

        public AItemData GetItemData(string nameId)
        {
            return _itens.Find(data => data.Id == nameId);
        }
        
    }
}