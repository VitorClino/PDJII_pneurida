using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioConfig : MonoBehaviour
{
    public AudioSource InGame;
    public AudioSource OutGame;
    public void TrocaAudio()
    {
        if (InGame.isPlaying)
        { 
            OutGame.Play();
            InGame.Stop();
        }
        else  if (OutGame.isPlaying)
        {
            OutGame.Stop();
            InGame.Play();
        }
    }

    public void Volume(Scrollbar scrollbar)
    {
        OutGame.volume = scrollbar.value;
        InGame.volume = scrollbar.value;
    }
}
