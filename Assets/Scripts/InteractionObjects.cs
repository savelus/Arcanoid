using UnityEngine;
using Zenject;

public class InteractionObjects : MonoBehaviour, IInitializable
{
    public Ball Ball;
    public Platform Platform;

    private Vector2 _platformStartPosition;
    private Vector2 _ballStartPosition;
    
    public void Initialize()
    {
        _ballStartPosition = Ball.transform.position;
        _platformStartPosition = Platform.transform.position;
    }

    public void SetupInteractionObjects()
    {
        SetupBall();
    }

    private void SetupBall()
    {
    }
}