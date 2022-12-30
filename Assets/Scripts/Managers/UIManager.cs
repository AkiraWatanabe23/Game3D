using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームシーン内のUIの表示をこのクラスで行う
/// </summary>
public class UIManager : MonoBehaviour
{
    [Tooltip("シーン上に表示するText")]
    [SerializeField] private Text[] _sceneTexts = new Text[5];

    private void Update()
    {
        _sceneTexts[0].text = GameManager.Timer.ToString("F0");
    }
}
