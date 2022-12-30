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
    private string _moveSceneName = default;

    private void Awake()
    {
        //現在のシーン名を取得
        _moveSceneName = SceneManager.GetActiveScene().name;
        //次にどのシーンに遷移するのかを決定する
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
        Debug.Log(_moveSceneName);
    }

    private void Start()
    {
        StartFadeIn();
    }

    public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public void StartFadeOut()
    {
        //フェードアウト→シーン遷移
        StartCoroutine(FadeOut(
            () => SceneLoaders.SceneLoad(_moveSceneName)));
    }

    //↓フェード処理の後に、実行したい関数があれば引数に設定する
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

        action?.Invoke();
    }
}