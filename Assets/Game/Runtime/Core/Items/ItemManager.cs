using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Runtime.Core.Items
{
    public class ItemManager : MonoBehaviour
    {
        [SerializeField] private Transform targetPosition;
        [SerializeField] private int spawnAmount = 5;
        private List<Item> _items = new List<Item>();
        private ItemFactory _itemFactory;

        [Inject] public void Init(ItemFactory itemFactory)
        {
            _itemFactory = itemFactory;
        }
        
        private void Start()
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                var item = _itemFactory.Crate(transform);
                _items.Add(item);
            }   
        }
    }
}
