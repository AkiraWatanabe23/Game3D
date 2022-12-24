using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [Tooltip("フェードさせるUI")]
    [SerializeField] private Image _fadePanel;
    [Tooltip("実行時間")]
    [Range(1f, 3f)]
    [SerializeField] private float _fadeSpeed = 0f;
}