using UnityEngine;

/// <summary>
/// SEを流すときに使う
/// </summary>
public class SoundManager : MonoBehaviour
{
    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 指定されたSEを再生する
    /// </summary>
    /// <param name="audio"> 再生する音 </param>
    public void AudioPlay(AudioClip audio)
    {
        _source.clip = audio;
        _source.PlayOneShot(audio);
    }
}
