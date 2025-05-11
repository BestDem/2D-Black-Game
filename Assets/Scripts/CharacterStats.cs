using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterStats", menuName = "Character Stats")]
public class CharacterStats : ScriptableObject
{
    [SerializeField] private string _characterName;
    [SerializeField] private int _health;
    [SerializeField] private int _coints;

    public string CharacterName => _characterName;
    public int Health => _health;
    public int Coints => _coints;
 
    //Обновление количества монет при старте
    //private void Start()
    //{
    //    if(PlayerPrefs.HasKey("Coint"))
    //        _coints = PlayerPrefs.GetInt("Coint");
    //}
    public void AddCoints(int amount)
    {
        _coints += amount;
        PlayerPrefs.SetInt("Coint", _coints);
    }

    public void DeleleKey()
    {
        PlayerPrefs.DeleteKey("Coint");
    }
}