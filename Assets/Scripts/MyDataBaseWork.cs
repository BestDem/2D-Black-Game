using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Character : MonoBehaviour
{
    [SerializeField] private CharacterStats _stats;
    [SerializeField] private List _inventory = new();


    private void Start()
    {
        Debug.Log($"Name: {_stats.CharacterName}, Health: {_stats.Health}, Attack: {_stats.Coints}");
        
    }

    private class List
    {
    }
}
