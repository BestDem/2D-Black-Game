using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMag : MonoBehaviour, IDamageable
{
    [SerializeField] private int damage;

    public void TakeDamagePlayer(float damage)
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Health>(out var health))
        {
            health.TakeDamagePlayer(damage);
            StartCoroutine(TestCoroutine());
        }
    }
    IEnumerator TestCoroutine()
    {
        yield return new WaitForSecondsRealtime(1f);
    }
}
