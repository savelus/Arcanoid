using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Events;

public class DownBorder : MonoBehaviour
{
    private UnityAction _onCollisionEnter;

    public void Initialize(UnityAction onDownBorderEnter)
    {
        _onCollisionEnter = null;
        _onCollisionEnter += onDownBorderEnter;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball _))
        {
            _onCollisionEnter?.Invoke();
        }
    }
}
