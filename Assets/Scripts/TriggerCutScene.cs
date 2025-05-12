using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCutScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            CutsceneManager.Instance.StartCutscene("cut_1");
            Destroy(this);
        }
    }
}
