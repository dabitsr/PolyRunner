using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] float repeatRate, minRepeatRate, maxRepeatRate;
    [SerializeField] bool randomRate;
    [SerializeField] List<AudioClip> audios;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        if (randomRate) Invoke("PlayAudio", Random.Range(minRepeatRate, maxRepeatRate));
        else InvokeRepeating("PlayAudio", repeatRate, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayAudio()
    {
        AudioClip a = audios[Random.Range(0, audios.Count)];
        audio.clip = a;
        audio.Play();

        if (randomRate)
            Invoke("PlayAudio", Random.Range(minRepeatRate, maxRepeatRate));
    }
}
