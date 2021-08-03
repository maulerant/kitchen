using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeDispenser : MonoBehaviour
{
    [SerializeField] private CakeCollector _cakeCollector;
    [SerializeField] private CakePlace _cakePlace;
    [SerializeField] private List<Cake> _cakeTemplates;
    [SerializeField] private Player _player;

    private int _currentCake;

    private void Start() 
    {
        DispenceCake();
    }

    private void OnEnable()
    {
       _cakeCollector.CakeCollected += OnCakeCollected; 
        _player.CakeBought += OnCakeBought;
    }

    private void OnDisable() 
    {
       _cakeCollector.CakeCollected -= OnCakeCollected; 
        _player.CakeBought -= OnCakeBought;
    }

    private void OnCakeCollected(Cake cake)
    {
        _cakePlace.RemoveCake(cake);
        DispenceCake();
    }

    private void DispenceCake()
    {
        int randomNumber = Random.Range(0, _cakeTemplates.Count);
        _cakePlace.SetCake(_cakeTemplates[randomNumber]);     
    }

    private void OnCakeBought(Cake cake)
    {
        _cakeTemplates.Add(cake);
    }
}
