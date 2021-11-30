using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioPlayerController
{
    public static void PlayAudio(AudioClip a)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.1f;
        audioSource.PlayOneShot(a);

        /*
        new WaitForSeconds(a.length);
        UnityEngine.Object.Destroy(soundGameObject);
        */
    }
}
