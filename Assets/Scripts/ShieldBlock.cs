using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ShieldBlock : StoneBlock
{
    [SerializeField] private int shield;
    [SerializeField] private TMP_Text viewShield;
    
    private int _currentShield;
    private UnityAction _destroyBlockAction;

    public void Initialize(UnityAction destroyBlockAction)
    {
        gameObject.SetActive(true);
        _currentShield = shield;
        _destroyBlockAction = destroyBlockAction;
        ViewShield();
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        CalculateShield();
    }

    private void CalculateShield()
    {
        if (_currentShield == 1)
        {
            gameObject.SetActive(false);
            _destroyBlockAction?.Invoke();
        }
        _currentShield--;
        ViewShield();
    }

    private void ViewShield()
    {
        viewShield.text = _currentShield.ToString();
    }
}