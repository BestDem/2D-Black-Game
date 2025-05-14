using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CointController : MonoBehaviour
{
    public static  CointController Instance;
    [SerializeField] private Text collectedCoins;
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private GameObject coint;

    private int initialCoins;

    private void Awake()
    {
        Instance = this;

        characterStats.CointsInStart();
        initialCoins = characterStats.StartCoints;
        
        collectedCoins.text = characterStats.Coints.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        characterStats.AddCoints(1);
        collectedCoins.text = characterStats.Coints.ToString();
        Destroy(coint);
    }

    public void ResetCoins()
    {
        PlayerPrefs.SetInt("Coint", initialCoins);
    }
}
