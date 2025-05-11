using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CointController : MonoBehaviour
{
    [SerializeField] private Text collectedCoins;
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private GameObject coint;

    private void Start()
    {
        collectedCoins.text = characterStats.Coints.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        characterStats.AddCoints(1);
        collectedCoins.text = characterStats.Coints.ToString();
        Destroy(coint);
    }
}
