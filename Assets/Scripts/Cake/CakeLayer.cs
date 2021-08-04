using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CakeLayer : MonoBehaviour
{
    [SerializeField] private int _clicksBeforeCooking;

    private SpriteRenderer _spriteRenderer;
    private Color _layerColor;

    public int CookingProgress { get; private set; }
    public int ClicksBeforeCooking => _clicksBeforeCooking;

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        _layerColor = _spriteRenderer.color;
        CreateGhostLayer();
    }

    private void CreateGhostLayer() 
    {
        _spriteRenderer.color = new Color(255, 255, 255, 100);
    }

    public void IncreaseCookingProgress() 
    {
        CookingProgress++;
    }

    public bool TryCookLayer() 
    {
        if (_clicksBeforeCooking != CookingProgress) 
        {
            return false;
        }
        _spriteRenderer.color = _layerColor;
        return true;
    }
}
