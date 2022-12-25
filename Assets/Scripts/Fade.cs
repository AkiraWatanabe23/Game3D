using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [Tooltip("�t�F�[�h������UI")]
    [SerializeField] private Image _fadePanel;
    [Tooltip("���s����")]
    [SerializeField] private float _fadeTime = 1f;

    [Header("�e�X�g�p")]
    [Tooltip("�w�肵���֐������s")]
    [SerializeField] private UnityEvent _event;

    private void Start()
    {
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
        //���l(�����x)�� 1 -> 0 �ɂ���(���������邭����)
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
        //���l(�����x)�� 0 -> 1 �ɂ���(�������Â�����)
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