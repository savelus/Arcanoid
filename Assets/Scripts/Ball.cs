using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public Rigidbody2D ballRigidbody;
    public float speed = 200f;
    private Vector2 force;
    public void Initialize(Vector2 position)
    {
        ballRigidbody.AddForce(Vector2.zero);
        transform.position = position;
        gameObject.SetActive(true);
        Invoke(nameof(SetRandomForce), 1f);
    }

    private void SetRandomForce()
    {
        force = Vector2.zero;
        force.x = Random.Range(-0.5f, 0.5f);
        force.y = 0.5f;
        force = force.normalized * speed;
        ballRigidbody.AddForce(force);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ballRigidbody.velocity *= 1.003f;
    }
}
