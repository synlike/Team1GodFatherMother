using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapSoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClips;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomGrapSound()
    {
        int index = Random.Range(0, audioClips.Length - 1);

        audioSource.PlayOneShot(audioClips[index]);
    }

}
