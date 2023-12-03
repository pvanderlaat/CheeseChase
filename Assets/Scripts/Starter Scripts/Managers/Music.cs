using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource _audioSource;
    // public AudioClip music;
    private void Awake()
    {
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Music");
        if (musicObjects.Length > 1)
        {
            return;
        }

        Debug.Log("Music awakening");
        // DontDestroyOnLoad(transform.gameObject);
        DontDestroyOnLoad(this.gameObject);
        _audioSource = GetComponent<AudioSource>();
        
        // Assign the AudioClip to the AudioSource
        // _audioSource.clip = music;

        // Make sure the audio source is set to loop if needed
        _audioSource.loop = true;
        PlayMusic();
    }

    public void PlayMusic()
    {
        Debug.Log("PLaying music");
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
