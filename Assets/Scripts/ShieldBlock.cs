using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ShieldBlock : StoneBlock
{
    public int shield;
    private int _shield;
    public TMP_Text viewShield;
    private UnityAction _checkEndAction;

    public void Initialize(UnityAction checkEndAction)
    {
        gameObject.SetActive(true);
        _shield = shield;
        _checkEndAction = checkEndAction;
        ViewShield();
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        CalculateShield();
    }

    private void CalculateShield()
    {
        if (_shield == 1)
        {
            gameObject.SetActive(false);
            _checkEndAction?.Invoke();
        }
        _shield--;
        ViewShield();
    }

    private void ViewShield()
    {
        viewShield.text = _shield.ToString();
    }
}