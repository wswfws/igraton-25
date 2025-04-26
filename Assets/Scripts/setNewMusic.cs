using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setNewMusic : MonoBehaviour
{
    private AudioSource targetAudioSource;
    
    [SerializeField] public AudioClip audioClip;
    void Start()
    {
        GameObject musicObject = GameObject.Find("music");

        if (musicObject != null)
        {
            targetAudioSource = musicObject.GetComponent<AudioSource>();
            ChangeMusic(audioClip);
        }
    }

    public void ChangeMusic(AudioClip newClip)
    {
        if (targetAudioSource != null && newClip != null)
        {
            targetAudioSource.Stop();
            targetAudioSource.clip = newClip;
            targetAudioSource.Play();
        }
    }
}
