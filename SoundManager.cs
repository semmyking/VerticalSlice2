using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sound;

    // Singleton instance.
    public static SoundManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        // Dont destroy when switching scenes 
        DontDestroyOnLoad(gameObject);
    }

    // Plays Audioclip that gets called
    public void Play(AudioClip clip)
    {
        sound.clip = clip;
        sound.Play();
    }

    // Plays a Random AudioClip from an Array 
    public void RandomSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        sound.clip = clips[randomIndex];
        sound.Play();
    }

}