using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private int _bakedCakes;

    public int BakedCakes => _bakedCakes;
    public event UnityAction<int> WalletAmountChanged;

    public void AddCakeProfit(int amount)
    {
        _bakedCakes += amount;
        WalletAmountChanged?.Invoke(_bakedCakes);
    }

    public void WithdrawCakeProfit(int amount)
    {
        _bakedCakes -= amount;
        WalletAmountChanged?.Invoke(_bakedCakes);
    }
}
