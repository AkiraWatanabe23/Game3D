using Consts;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    [Tooltip("フェードさせるUI")]
    [SerializeField] private Image _fadePanel;
    [Tooltip("実行時間")]
    [SerializeField] private float _fadeTime = 1f;

    /// <summary> 遷移先のシーン名 </summary>
    private static string _moveSceneName = default;

    public static string MoveSceneName => _moveSceneName;

    private void Awake()
    {
        //現在のシーン名を取得
        _moveSceneName = SceneManager.GetActiveScene().name;
        //次にどのシーンに遷移するのかを決定する(問題点：シーン数が固定になる...)
        if (_moveSceneName == Define.TITLE_NAME)
        {
            _moveSceneName = Define.INGAME_NAME;
        }
        else if (_moveSceneName == Define.INGAME_NAME)
        {
            _moveSceneName = Define.RESULT_NAME;
        }
        else if (_moveSceneName == Define.RESULT_NAME)
        {
            _moveSceneName = Define.TITLE_NAME;
        }
    }

    private void Start()
    {
        StartFadeIn();
    }

    public void StartFadeIn(Action action = null)
    {
        StartCoroutine(FadeIn());
        //フェード後に実行する関数
        action?.Invoke();
    }

    public void StartFadeOut(Action action = null)
    {
        //フェードアウト→シーン遷移
        StartCoroutine(FadeOut());
        //フェード後に実行する関数
        action?.Invoke();
    }

    private IEnumerator FadeIn()
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
    }

    private IEnumerator FadeOut()
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
    }
}