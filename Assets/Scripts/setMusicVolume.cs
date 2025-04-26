using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMusicVolume : MonoBehaviour
{
    private AudioSource audioSource;
    
    void Start()
    {
        GameObject musicObject = GameObject.Find("music");
        if (musicObject != null)
        {
            audioSource = musicObject.GetComponent<AudioSource>();
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (audioSource != null)
        {
            // Ограничиваем значение в диапазоне 0-1
            volume = Mathf.Clamp01(volume);
            audioSource.volume = volume;
            Debug.Log($"Music volume set to: {volume}");
        }
        else
        {
            Debug.LogError("AudioSource is null - cannot set volume!");
        }
    }
}
