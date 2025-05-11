using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCutScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            CutsceneManager.Instance.StartCutscene("cut_1");

        }
    }
}
