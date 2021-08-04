using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cake : MonoBehaviour
{
    [SerializeField] private int _profit;

    private CakeLayer[] _layers;
    private int _createdLayers;

    public bool Done => _createdLayers == _layers.Length;
    public int Profit => _profit;

    public event UnityAction CakeDone;
    public event UnityAction<float, float> CakeLayerProgresses;

    private void Start() 
    {
        _layers = GetComponentsInChildren<CakeLayer>();
        _createdLayers = 0;
    }

    public void OnClick()
    {
        Debug.Log("on click");
        if(!Done && TryBakeLayer()) 
        {
            if(Done)
            {
                CakeDone?.Invoke();
            }
        }

    }

    private bool TryBakeLayer() 
    {
        CakeLayer cakeLayer = _layers[_createdLayers];

        cakeLayer.IncreaseCookingProgress();
        CakeLayerProgresses?.Invoke(cakeLayer.CookingProgress, cakeLayer.ClicksBeforeCooking);

        if(!cakeLayer.TryCookLayer()) {
            return false;
        }
        _createdLayers++;
        return true;
    }
}
