using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WalletDisplay : MonoBehaviour
{
    [SerializeField] PlayerWallet _playerWallet;
    [SerializeField] TMP_Text _walletAmount;

    private void OnEnable() 
    {
        _playerWallet.WalletAmountChanged += OnWalletAmountChanged;  
    }

    private void OnDisable() 
    {
        _playerWallet.WalletAmountChanged -= OnWalletAmountChanged;  
    }

    private void OnWalletAmountChanged(int amount)
    {
        _walletAmount.text = amount.ToString();
    }
}
