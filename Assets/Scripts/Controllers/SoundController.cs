using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController soundCon;

    [SerializeField]
    AudioSource audioSourceMusic;
    [SerializeField]
    public AudioSource audioSourceObject;

    [SerializeField]
    AudioClip[] audioObject;
    [SerializeField]
    AudioClip[] audioMusic;
    private int audioCounter = 0;
      

    private void Start()
    {
        if (soundCon == null)
            soundCon = GetComponent<SoundController>();
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        audioSourceMusic = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!audioSourceMusic.isPlaying)
        {
            audioSourceMusic.clip = audioMusic[audioCounter];
            audioSourceMusic.Play();

            if (audioMusic.Length > audioCounter + 1) 
                audioCounter++;
            else
                audioCounter = 0;
        }
    }

    public void PlaySound(string objectSound)
    {
        if (audioSourceObject == null)
        {
        }

        if (objectSound == "button")
            audioSourceObject.clip = audioObject[0];
        else if (objectSound == "change")
            audioSourceObject.clip = audioObject[1];
        else if (objectSound == "coin")
            audioSourceObject.clip = audioObject[2];
        else if (objectSound == "restart")
            audioSourceObject.clip = audioObject[3];
        else if (objectSound == "portal")
            audioSourceObject.clip = audioObject[4];

        audioSourceObject.Play();
    }
}
