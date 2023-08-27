using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muzyczka : MonoBehaviour
{
    public AudioSource musicSource;
    private bool isMusicPaused = false;

    private void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        musicSource.Play();
        isMusicPaused = false;
    }

    public void PauseMusic()
    {
        musicSource.Pause();
        isMusicPaused = true;
    }

    public void ResumeMusic()
    {
        musicSource.UnPause();
        isMusicPaused = false;
    }
}
