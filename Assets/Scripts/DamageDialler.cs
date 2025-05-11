using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDialler : MonoBehaviour
{   
    //для пули
    [SerializeField] private float damage;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("IgnorBullet"))
        {
            return;
        }
        
        if(collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamagePlayer(damage);
        }

        Destroy(gameObject);
    }
}
