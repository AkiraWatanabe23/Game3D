using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("ゲームを終了するキー")]
    [SerializeField] private KeyCode _closeKey;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(_closeKey))
        {
            GameClose();
        }
    }

    /// <summary>
    /// ゲームを終了する
    /// </summary>
    private void GameClose()
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
