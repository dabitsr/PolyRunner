using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioPlayerController
{
    [SerializeField] static float volume = 0.1f;

    public static void PlayAudio(AudioClip a)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.volume = volume;
        audioSource.PlayOneShot(a);

        /*
        new WaitForSeconds(a.length);
        UnityEngine.Object.Destroy(soundGameObject);
        */
    }

    public static void PlayAudio(AudioClip a, float v)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.volume = v;
        audioSource.PlayOneShot(a);
    }
}
