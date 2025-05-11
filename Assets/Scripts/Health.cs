using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    [SerializeField] private UnityEvent<float, float> EventChange;
    [SerializeField] private UnityEvent EventDeath;

    private float currentHealth;

    public float MaxHealth => maxHealth;
    public bool IsDeath => currentHealth <= 0;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        EventChange?.Invoke(maxHealth, currentHealth);
    }

    public void TakeDamagePlayer(float damage)
    {
        currentHealth -= Mathf.Abs(damage);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        EventChange?.Invoke(maxHealth, currentHealth);

        Debug.Log("осталось" + currentHealth);

        if(IsDeath)
        {
            EventDeath?.Invoke();
        }
    }
    
}