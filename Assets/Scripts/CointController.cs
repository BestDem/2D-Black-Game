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

        initialCoins = characterStats.Coints;
        PlayerPrefs.SetInt("InitialCoins", initialCoins);

        
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
        //characterStats.DeleleKey();
        PlayerPrefs.SetInt("Coint", initialCoins);   // Устанавливает начальное значение
        collectedCoins.text = initialCoins.ToString();
    }
}
