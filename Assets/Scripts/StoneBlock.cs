using System;
using Unity.VisualScripting;
using UnityEngine;

public class StoneBlock : MonoBehaviour
{
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        print(name);
    }
}