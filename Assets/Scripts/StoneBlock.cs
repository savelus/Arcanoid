using UnityEngine;

public class StoneBlock : MonoBehaviour
{
    [SerializeField]
    public BlockType BlockType;
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        print(name);
    }
}