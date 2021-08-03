using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    [SerializeField] private int _profit;

    private CakeLayer[] _layers;
    private int _createdLayers;

    public bool Done => _createdLayers == _layers.Length;

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
                Debug.Log("Cake baked");
            }
        }

    }

    private bool TryBakeLayer() 
    {
        CakeLayer cakeLayer = _layers[_createdLayers];

        cakeLayer.IncreaseCookingProgress();
        if(cakeLayer.TryCookLayer()) {
            _createdLayers++;
            return true;
        }
        return false;
    }
}
