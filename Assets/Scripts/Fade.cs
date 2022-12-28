using Consts;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [Tooltip("フェードさせるUI")]
    [SerializeField] private Image _fadePanel;
    [Tooltip("実行時間")]
    [SerializeField] private float _fadeTime = 1f;

    /// <summary> このクラスのインスタンス </summary>
    private static Fade _instance = default;
    /// <summary> 遷移先のシーン名 </summary>
    private string _sceneName = Define.TITLE_NAME;

    public string SceneName => _sceneName;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }


        //現在のシーンが遷移する時にどのシーンに遷移するのかを決定する
        if (_sceneName == Define.TITLE_NAME)
        {
            _sceneName = Define.INGAME_NAME;
        }
        else if (_sceneName == Define.INGAME_NAME)
        {
            _sceneName = Define.RESULT_NAME;
        }
        else if (_sceneName == Define.RESULT_NAME)
        {
            _sceneName = Define.TITLE_NAME;
        }
        Debug.Log(_sceneName);
    }

    private void Start()
    {
        //フェード -> シーン遷移 の流れのテスト
        StartFadeOut();
    }

    //↓フェード処理の後に、実行したい関数があれば引数に設定する
    public static void StartFadeIn()
    {
        _instance.StartCoroutine(_instance.FadeIn());
    }

    public static void StartFadeOut()
    {
        _instance.StartCoroutine(_instance.FadeOut(() => SceneLoaders.SceneLoad(_instance.SceneName)));
    }

    private IEnumerator FadeIn(Action action = null)
    {
        _fadePanel.gameObject.SetActive(true);

        //α値(透明度)を 1 -> 0 にする(少しずつ明るくする)
        float alpha = 1f;
        Color color = _fadePanel.color;

        do
        {
            alpha -= Time.deltaTime * (1f /_fadeTime);
            if (alpha <= 0f)
            {
                alpha = 0f;
            }
            color.a = alpha;
            _fadePanel.color = color;
            yield return null;
        }
        while (alpha > 0f);

        _fadePanel.gameObject.SetActive(false);
        action?.Invoke();
    }

    private IEnumerator FadeOut(Action action = null)
    {
        _fadePanel.gameObject.SetActive(true);

        //α値(透明度)を 0 -> 1 にする(少しずつ暗くする)
        float alpha = 0f;
        Color color = _fadePanel.color;

        do
        {
            alpha += Time.deltaTime * (1f / _fadeTime);
            if (alpha >= 1f)
            {
                alpha = 1f;
            }
            color.a = alpha;
            _fadePanel.color = color;
            yield return null;
        }
        while (alpha < 1f);

        Debug.Log("FadeComplete");
        action?.Invoke();
    }
}