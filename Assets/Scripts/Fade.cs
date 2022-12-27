using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [Tooltip("フェードさせるUI")]
    [SerializeField] private Image _fadePanel;
    [Tooltip("実行時間")]
    [SerializeField] private float _fadeTime = 1f;

    private static Fade _instance = default;

    private void Awake()
    {
        _instance = this;
    }

    //↓フェード処理の後に、実行したい関数があれば引数に設定する
    public static void StartFadeIn()
    {
        _instance.StartCoroutine(_instance.FadeIn());
    }

    public static void StartFadeOut()
    {
        _instance.StartCoroutine(_instance.FadeOut());
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

        Debug.Log("FadeOut");
    }
}