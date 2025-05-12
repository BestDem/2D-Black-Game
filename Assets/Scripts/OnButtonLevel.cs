using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnButtonLevel : MonoBehaviour
{
    [SerializeField] private int indexLevel;

    public void OnButtonLevelStart()
    {
        SceneManager.LoadScene(indexLevel);
    }
}
