using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sonido[] Sonidomusica, sfxSonido;
    public AudioSource musicSource, sfxSource;
    

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusica("Musica de fondo");
    }




    public void PlayMusica(string name)
    {
        Sonido a = Array.Find(Sonidomusica, x => x.nombre == name);
        if (a == null) 
        {
            Debug.Log("No se encontro el sonido");
        }
        else
        {
            musicSource.clip= a.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name) 
    {
        Sonido a = Array.Find(sfxSonido, x => x.nombre == name);
        if (a == null)
        {
            Debug.Log("No se encontro el sonido");
        }
        else
        {
            sfxSource.PlayOneShot(a.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
