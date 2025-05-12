using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private Bullet bulletpPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float seeDistance = 15f;
    bool isBusy = false;

    private void Update()
    {
        if(!isBusy && Vector2.Distance(player.transform.position, transform.position) <= seeDistance)
        {
            StartCoroutine(TestCoroutine());
        }
    }

    private void ShootEnemy()
    {
        Bullet currentBullet = Instantiate(bulletpPrefab, firePoint.position, Quaternion.identity);

        Vector2 direction = new Vector2(-1, 0);
        
        currentBullet.Initialize(direction);
    }
    
    IEnumerator TestCoroutine()
    {
        isBusy = true;

        yield return new WaitForSecondsRealtime(1f);

        ShootEnemy();

        isBusy = false;
    }
}
