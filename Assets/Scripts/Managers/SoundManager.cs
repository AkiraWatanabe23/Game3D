using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SE‚ð—¬‚·‚Æ‚«‚ÉŽg‚¤
/// </summary>
public class SoundManager : MonoBehaviour
{
    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void AudioPlay(AudioClip audio)
    {
        _source.clip = audio;
        _source.PlayOneShot(audio);
    }
}
