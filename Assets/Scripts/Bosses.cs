using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosses : MonoBehaviour
{
    [SerializeField] private GameObject bosses;
    [SerializeField] private Animator animator; 
    public void SetActivBoss()
    {
        animator.SetBool("isSpawn",true);
        bosses.SetActive(true);

        StartCoroutine(TestCoroutine());

        animator.SetBool("isRunning",true);
    }

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSecondsRealtime(1f);
    }
}
