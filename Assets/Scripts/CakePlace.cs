using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CakePlace : MonoBehaviour
{
    [SerializeField] private Cake _cake;
    [SerializeField] private ClickerZone _clickerZone;

    public event UnityAction<Cake> CakeReadyForCollect;

    public void SetCake(Cake cake)
    {
        _cake = Instantiate(cake, transform);
        _clickerZone.Click += _cake.OnClick;
        _cake.CakeDone += OnCakeDone;
    }

    public void RemoveCake(Cake cake)
    {
        _clickerZone.Click -= _cake.OnClick;
        _cake.CakeDone -= OnCakeDone;
        Destroy(cake);
    }

    private void OnCakeDone()
    {
        CakeReadyForCollect?.Invoke(_cake);
    }

}
