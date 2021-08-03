using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class CakeCollector : MonoBehaviour
{
    [SerializeField] private CakePlace _cakePlace;
    [SerializeField] private Button _collectButton;

    private CanvasGroup _canvasGroup;
    private Cake _targetCake;

    public event UnityAction<Cake> CakeCollected;

    private void Start() {
        _canvasGroup = GetComponent<CanvasGroup>();
        Close();
    }

    private void OnEnable() {
        _cakePlace.CakeReadyForCollect += OnCakeReadyForCollect;
        _collectButton.onClick.AddListener(CollectCake);
    }

    private void OnDisable() {
        _cakePlace.CakeReadyForCollect -= OnCakeReadyForCollect;
        _collectButton.onClick.RemoveListener(CollectCake);
    }

    private void OnCakeReadyForCollect(Cake cake)
    {
        _targetCake = cake;
        Open();   
    }

    private void CollectCake()
    {
        Close();
        CakeCollected?.Invoke(_targetCake);
    }

    private void Open() 
    {
        _canvasGroup.alpha = 1;     
    }

    private void Close() 
    {
        _canvasGroup.alpha = 0;     
    }
}
