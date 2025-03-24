using UnityEngine;

public class MusicSoundController : MonoBehaviour
{
    public static MusicSoundController instance;

    public AudioSource MusicSource, SoundSource;
    public AudioClip ButtonClickClip,DeadPlayerClip;

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

        //PlayerPrefs.DeleteAll();

        LoadMusicAndSoundData();
    }

       
    public void LoadMusicAndSoundData()
    {
        if (PlayerPrefs.GetInt("GAME_START") == 0)
        {
            if (PlayerPrefs.GetFloat("MUSIC") == 0f)
                PlayerPrefs.SetFloat("MUSIC", 1);

            if (PlayerPrefs.GetFloat("SOUND") == 0f)
                PlayerPrefs.SetFloat("SOUND", 1);


            PlayerPrefs.SetInt("GAME_START", 1);
        }

        MusicSourceValueChanged(PlayerPrefs.GetFloat("MUSIC"));
        SoundSourceValueChanged(PlayerPrefs.GetFloat("SOUND"));
    }


    public void MusicPlay(bool _status)
    {
        if (MusicSource != null)
        {
            if (MusicSource.clip != null)
            {
                if (_status == true)
                    MusicSource.Play();
                else
                    MusicSource.Stop();
            }
        }
    }

    public void ButtonClickSound()
    {
        if (SoundSource != null)
        {
            SoundSource.clip = ButtonClickClip;
            SoundSource.PlayOneShot(SoundSource.clip);
        }
    }

    public void MusicSourceValueChanged(float value)
    {
        if (MusicSource != null)
        {            
            MusicSource.volume = value;

            // save value
            PlayerPrefs.SetFloat("MUSIC", value);
        }
    }

    public void SoundSourceValueChanged(float value)
    {
        if (SoundSource != null)
        {
            SoundSource.volume = value;

            // save value
            PlayerPrefs.SetFloat("SOUND", value);
        }
    }



    public void DeadPlayerSound()
    {
        if (SoundSource != null)
        {
            SoundSource.clip = DeadPlayerClip;
            SoundSource.PlayOneShot(SoundSource.clip);

            // Music Off
            MusicPlay(false);
        }
    }
}
