using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingProgress : MonoBehaviour
{
    [SerializeField] private Slider _cookingProgress;
    [Range(0, 5)]
    [SerializeField] private float _fillingSpeed;

    private float _targetProgress;

    private void Update()
    {
        _cookingProgress.value = Mathf.Lerp(_cookingProgress.value, _targetProgress, _fillingSpeed);    
    }

    public void ResetProgress()
    {
        _targetProgress = 0;
    }

    public void OnCakeLayerCookingProgress(float currentProgress, float needValue)
    {
        _targetProgress = currentProgress / needValue;
    }
}
