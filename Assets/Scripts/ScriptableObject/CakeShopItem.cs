using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cake", menuName = "Cake Item", order = 51)]
public class CakeShopItem : ScriptableObject 
{
    [SerializeField] private Cake _cake;
    [SerializeField] private string _label;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;

    public bool IsBuy { get; private set; }

    public string Label => _label;
    public Cake Cake => _cake;
    public Sprite Icon => _icon;
    public int Price => _price;
    public int CakeProfit => _cake.Profit;

    public void Buy()
    {
        IsBuy = true;
    }
}