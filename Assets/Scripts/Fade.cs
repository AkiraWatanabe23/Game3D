using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [Tooltip("フェードさせるUI")]
    [SerializeField] private Image _fadePanel;
    [Tooltip("実行時間")]
    [SerializeField] private float _fadeTime = 1f;

    [Header("テスト用")]
    [Tooltip("指定した関数を実行")]
    [SerializeField] private UnityEvent _event;

    private void Start()
    {
        //テストでフェードイン、アウトを行う
        _event?.Invoke();
    }

    public void StartFadeIn()
    {
        _fadePanel.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    public void StartFadeOut()
    {
        _fadePanel.gameObject.SetActive(true);
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
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
        SceneLoaders.LoadInGame();
    }
}