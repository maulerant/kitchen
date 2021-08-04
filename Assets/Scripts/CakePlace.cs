using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CakePlace : MonoBehaviour
{
    [SerializeField] private Cake _cake;
    [SerializeField] private ClickerZone _clickerZone;
    [SerializeField] private CookingProgress _cookingProgress;

    public event UnityAction<Cake> CakeReadyForCollect;

    public void SetCake(Cake cake)
    {
        _cake = Instantiate(cake, transform);
        _clickerZone.Click += _cake.OnClick;
        _cake.CakeDone += OnCakeDone;
        _cake.CakeLayerProgresses += _cookingProgress.OnCakeLayerCookingProgress;
    }

    public void RemoveCake(Cake cake)
    {
        _clickerZone.Click -= _cake.OnClick;
        _cake.CakeDone -= OnCakeDone;
        _cake.CakeLayerProgresses -= _cookingProgress.OnCakeLayerCookingProgress;
        _cookingProgress.OnCakeLayerCookingProgress(0, 100);
        Destroy(cake);
    }

    private void OnCakeDone()
    {
        CakeReadyForCollect?.Invoke(_cake);
    }
}
