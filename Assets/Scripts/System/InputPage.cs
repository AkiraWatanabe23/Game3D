using UnityEngine;
using UnityEngine.Events;

/// <summary> ヘルプ関連のInputをまとめる </summary>
public class InputPage : MonoBehaviour, IPause
{
    [Tooltip("ゲームを閉じるキー")]
    [SerializeField] private KeyCode _closeKey = KeyCode.Escape;
    [Tooltip("HelpPageを開くキー(アイテムリストとかもここにまとめる)")]
    [SerializeField] private KeyCode _helpKey = KeyCode.Tab;
    /// <summary> HelpPageを開くEvent </summary>
    [SerializeField] private UnityEvent _openHelp = default;
    /// <summary> HelpPageを閉じるEvent(ページの途中で閉じる場合) </summary>
    [SerializeField] private UnityEvent _closeHelp = default;

    private void Update()
    {
        if (Input.GetKeyDown(_closeKey))
        {
            //ゲームを終了する(テスト)
            GameClose();
        }

        //ゲームの一時停止
        if (Input.GetKeyDown(_helpKey))
        {
            if (!GameManager.IsPause)
            {
                Pause();
                _openHelp?.Invoke();
            }
            else
            {
                Resume();
                _closeHelp?.Invoke();
            }
        }
    }

    /// <summary> ゲームを閉じる(UIでも設定できるようにpublic) </summary>
    public void GameClose()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    public void Pause()
    {
        GameManager.IsPause = true;
        Debug.Log("Pause");
    }

    public void Resume()
    {
        GameManager.IsPause = false;
        Debug.Log("Resume");
    }
}
