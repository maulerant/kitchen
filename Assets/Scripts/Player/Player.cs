using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerWallet))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private CakeCollector _cakeCollector;

    public event UnityAction<Cake> CakeBought;

    private void Start() 
    {
        _wallet = GetComponent<PlayerWallet>();
    }

    private void OnEnable() 
    {
        _cakeCollector.CakeCollected += OnCakeCollected;        
    }

    private void OnDisable() 
    {
        _cakeCollector.CakeCollected -= OnCakeCollected;        
    }

    private void OnCakeCollected(Cake cake)
    {
        _wallet.AddCakeProfit(cake.Profit);
    }

    public void BuyCake(CakeShopItem cakeItem)
    {
        _wallet.WithdrawCakeProfit(cakeItem.Price);
         CakeBought?.Invoke(cakeItem.Cake);
    }

    public bool CanPay(int price)
    {
        return _wallet.BakedCakes <= price;
    }
}
