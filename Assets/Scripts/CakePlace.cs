using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakePlace : MonoBehaviour
{
    [SerializeField] private Cake _cake;
    [SerializeField] private ClickerZone _clickerZone;

    private void Start() {
        SetCake(_cake);
    }

    public void SetCake(Cake cake)
    {
        _cake = Instantiate(cake, transform);
        _clickerZone.Click += _cake.OnClick;
    }

    public void RemoveCake(Cake cake)
    {
        _clickerZone.Click -= _cake.OnClick;
        Destroy(cake);
    }

}
