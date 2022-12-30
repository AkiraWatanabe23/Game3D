using UnityEngine;

/// <summary>
/// SEを流すときに使う
/// </summary>
public class SoundManager : MonoBehaviour
{
    [Tooltip("SEの配列")]
    [SerializeField] private AudioClip[] _clips = new AudioClip[5];

    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 指定されたSEを再生する
    /// </summary>
    /// <param name="index"> SEの配列のインデックス </param>
    public void AudioPlay(int index)
    {
        _source.clip = _clips[index];
        _source.PlayOneShot(_clips[index]);
    }
}
