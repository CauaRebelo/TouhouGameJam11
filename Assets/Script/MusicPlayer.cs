using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public AudioSource src;
    public AudioClip musica;
    public bool precisaGuardar;
    public float storeTime;

    void Awake()
    {
        src = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>()._audioSource;
        if (precisaGuardar) 
        {
            storeTime = src.time;
            src.Stop();
            src.clip = musica;
            src.Play();
            src.time = storeTime;
        }
        else
        {
            src.Stop();
            src.clip = musica;
            src.Play();
        }
    }

}
