using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;

    private CakeShopItem _cakeItem;

    public UnityAction<Item, CakeShopItem> BuyCake;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnBuyButtonClick);    
        _buyButton.onClick.AddListener(CheckCakeState);    
    }

    private void OnDisable() 
    {
        _buyButton.onClick.RemoveListener(OnBuyButtonClick);    
        _buyButton.onClick.RemoveListener(CheckCakeState);    
    }

    public void SetCakeItem(CakeShopItem cakeItem)
    {
        _cakeItem = cakeItem;
        FillItemInfo(cakeItem);
    }

    private void FillItemInfo(CakeShopItem cakeItem)
    {
        _label.text = cakeItem.Label;
        _price.text = cakeItem.Price.ToString();
        _icon.sprite = cakeItem.Icon;
    }

    private void OnBuyButtonClick()
    {
        BuyCake?.Invoke(this, _cakeItem);
        _cakeItem.Buy();
    }

    private void CheckCakeState()
    {
        if(_cakeItem.IsBuy)
        {
            _buyButton.interactable = false;
            _label.text = "Sell";
        }
    }

}
