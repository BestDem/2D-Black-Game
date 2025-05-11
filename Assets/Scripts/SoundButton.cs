using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    private AudioSource audio;

    public void OnClikSound()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
