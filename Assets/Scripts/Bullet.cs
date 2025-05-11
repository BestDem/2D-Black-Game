using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int fireSpeed;
    [SerializeField] private Rigidbody2D currentBulletVectory;

    public void Initialize(Vector2 direction)
    {
        currentBulletVectory.velocity = direction * fireSpeed;
    }
}
