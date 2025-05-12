using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //для игрока
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Bullet bulletpPrefab;
    private bool isShoot = true;

    public void FireButtonDown(bool isFireButtonPress)
    {
        if (isFireButtonPress && isShoot)
        {
            StartCoroutine(Enumerator());
            Shoot();
        }
    }
    private void Shoot()
    {
        Bullet currentBullet = Instantiate(bulletpPrefab, firePoint.position, Quaternion.identity);

        bool isLookRight = playerMovement.IsLookRight;
        Vector2 direction = new Vector2(isLookRight ? 1 : -1, 0);
        
        currentBullet.Initialize(direction);
    }
    IEnumerator Enumerator()
    {
        isShoot = false;
        yield return new WaitForSecondsRealtime(0.5f);
        isShoot = true;
    }
}
