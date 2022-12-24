using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [Tooltip("�t�F�[�h������UI")]
    [SerializeField] private Image _fadePanel;
    [Tooltip("���s����")]
    [Range(1f, 3f)]
    [SerializeField] private float _fadeSpeed = 0f;
}