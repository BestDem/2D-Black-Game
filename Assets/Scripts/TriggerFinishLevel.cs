using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFinishLevel : MonoBehaviour
{
    [SerializeField] private GameObject needMoreCoint;
    [SerializeField] private CharacterStats characterStats;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(characterStats.Coints == 5)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else
                needMoreCoint.SetActive(true);
        }    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        needMoreCoint.SetActive(false);
    }
}
