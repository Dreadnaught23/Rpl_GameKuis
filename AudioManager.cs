using System;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public Suara[] suara;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(gameObject);

        foreach(Suara s in suara)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string nama)
    {
       Suara s = Array.Find(suara,sound => sound.nama == nama);
       if (s == null)
        {
            Debug.LogWarning("Suara : " +  nama + "Tidak ditemukan!");
            return;
        }
       s.source.Play();
    }

}
