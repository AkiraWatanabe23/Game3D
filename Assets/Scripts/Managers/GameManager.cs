using Consts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IPause
{
    [Tooltip("テスト用の無敵状態")]
    [SerializeField] private static bool _isGodMode = false;
    [Tooltip("一時停止するキー")]
    [SerializeField] private KeyCode _pauseKey;
    [Tooltip("ゲームを終了するキー")]
    [SerializeField] private KeyCode _closeKey;
    [Tooltip("Playerの初期位置をランダムで決める")]
    [SerializeField] private Transform[] _spawnPos = new Transform[4];
    [SerializeField] private GameObject _playerPrefab;

    private static float _timer = 0f;
    private bool _isPause = false;

    public static bool IsGodMode => _isGodMode;
    public static float Timer { get => _timer; set => _timer = value; }

    private void Awake()
    {
        //もしシーンが第一階層ならタイマーをリセットする
        if (SceneManager.GetActiveScene().name == 
            Define.Scenes[SceneNames.FF_SCENE])
        {
            _timer = Define.GAME_TIME;
        }
        //TODO：Playerを、設定したスポーン位置の内のいずれかにランダムで生成する
        //Instantiate(_playerPrefab, _spawnPos[Random.Range(0, _spawnPos.Length)]);
    }

    private void Update()
    {
        if (!_isPause)
        {
            _timer -= Time.deltaTime;
        }

        if (_timer <= 0f)
        {
            //TODO：制限時間が0になった時に勝利判定をする
            SceneLoaders.PassToLoad
                (Define.Scenes[SceneNames.RESULT_SCENE]);
        }

        //指定したキーを入力し、ゲームの実行を一時停止する
        if (Input.GetKeyDown(_pauseKey))
        {
            if (!_isPause)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }

        //指定したキーを入力し、ゲームの実行を終了する
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

    public void Pause()
    {
        //TODO：一時停止処理の記述
        //一時停止するもの
        //->制限時間
        _isPause = true;
        Debug.Log("Pause");
    }

    public void Resume()
    {
        //TODO：処理再開の記述
        _isPause = false;
        Debug.Log("Resume");
    }
}
