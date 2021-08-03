using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<CakeShopItem> _cakes;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _itemContainer;
    [SerializeField] private Item _template;

    private void Start()
    {
        for (int i = 0; i < _cakes.Count; i++) {
            AddItem(_cakes[i]);
        }   
    }

    private void AddItem(CakeShopItem cakeItem)
    {
        Item item = Instantiate(_template, _itemContainer);
        InitializeItem(item, cakeItem);
    }

    private void InitializeItem(Item item, CakeShopItem cakeItem)
    {
        item.SetCakeItem(cakeItem);
        item.BuyCake += OnBuyCake;
        item.name = _template.name + (transform.childCount + 1).ToString();
    }

    private void OnBuyCake(Item item, CakeShopItem cakeItem)
    {
       TryBuyCake(item, cakeItem); 
    }

    private void TryBuyCake(Item item, CakeShopItem cakeItem)
    {
        if(_player.CanPay(cakeItem.Price))
        {
            _player.BuyCake(cakeItem);
            cakeItem.Buy();
            UnsubscribeItem(item);
        }
    }

    private void UnsubscribeItem(Item item)
    {
            item.BuyCake -= OnBuyCake;
    }
}
