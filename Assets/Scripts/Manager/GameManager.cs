using Consts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IPause
{
    [Tooltip("一時停止するキー")]
    [SerializeField] private KeyCode _pauseKey;
    [Tooltip("ゲームを終了するキー")]
    [SerializeField] private KeyCode _closeKey;
    [Tooltip("Playerの初期位置をランダムで決める")]
    [SerializeField] private List<Transform> _playerSpawn = new();
    [SerializeField] private GameObject _playerPrefab;

    private static bool _isPause = false;
    private static float _timer = 0f;

    public static bool IsPause { get => _isPause; set => _isPause = value; }
    public static float Timer { get => _timer; set => _timer = value; }

    private void Awake()
    {
        //もしシーンが第一階層ならタイマーをリセットする(それ以外ではタイマーを引き継ぐ)
        if (SceneManager.GetActiveScene().name == 
            Define.Scenes[SceneNames.FF_SCENE])
        {
            _timer = Define.GAME_TIME;
        }
        //TODO：Playerを設定したスポーン位置の内のいずれかにランダムで生成する
        Instantiate(_playerPrefab, _playerSpawn[Random.Range(0, _playerSpawn.Count)]);
    }

    private void Update()
    {
        //実行中のみ制限時間のカウントをする
        if (!_isPause)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                //TODO：制限時間が0になった時に勝利判定をする
                SceneLoaders.PassToLoad(Define.Scenes[SceneNames.RESULT_SCENE]);
            }
        }

        //ゲームの一時停止
        if (Input.GetKeyDown(_pauseKey))
        {
            if (!_isPause)
                Pause();
            else
                Resume();
        }

        //ゲームの終了
        if (Input.GetKeyDown(_closeKey))
            GameClose();
    }

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
        _isPause = true;
        Debug.Log("Pause");
    }

    public void Resume()
    {
        _isPause = false;
        Debug.Log("Resume");
    }
}