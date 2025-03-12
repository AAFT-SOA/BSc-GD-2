using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSoundController : MonoBehaviour
{
    public static MusicSoundController instance;


    public AudioSource MusicSource, SoundSource;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        MusicPlay(true);
    }

    public void MusicPlay(bool _status)
    {
        if (MusicSource != null)
        {
            Debug.Log("aaaaaaaa");
            if (MusicSource.clip != null)
            {
                if (_status == true)
                    MusicSource.Play();
                else
                    MusicSource.Stop();
            }
        }
    }

}
