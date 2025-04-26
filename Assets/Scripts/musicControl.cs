using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    private AudioSource audioSource; // Ссылка на компонент AudioSource

    // Start вызывается перед первым кадром
    void Start()
    {
        // Получаем компонент AudioSource у этого объекта
        audioSource = GetComponent<AudioSource>();
        
        // Проверяем, есть ли AudioSource
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this object!");
        }
    }

    // Функция для изменения AudioClip
    public void ChangeAudioClip(AudioClip newClip)
    {
        if (audioSource != null && newClip != null)
        {
            audioSource.clip = newClip;
            Debug.Log("AudioClip changed to: " + newClip.name);
        }
        else
        {
            Debug.LogError("AudioSource or newClip is null!");
        }
    }

    // Функция для изменения AudioClip и автоматического воспроизведения
    public void ChangeAndPlayAudioClip(AudioClip newClip)
    {
        if (audioSource != null && newClip != null)
        {
            audioSource.Stop(); // Останавливаем текущее воспроизведение
            audioSource.clip = newClip;
            audioSource.Play(); // Начинаем воспроизведение нового клипа
            Debug.Log("AudioClip changed and playing: " + newClip.name);
        }
        else
        {
            Debug.LogError("AudioSource or newClip is null!");
        }
    }
}