using Consts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("テスト用の無敵状態")]
    [SerializeField] private static bool _isGodMode = false;
    [Tooltip("ゲームを終了するキー")]
    [SerializeField] private KeyCode _closeKey;
    [Tooltip("フェード処理を実行するオブジェクト")]
    [SerializeField] private Fade _fadeObject;
    [Tooltip("Playerの初期位置をランダムで決める")]
    [SerializeField] private Transform[] _spawnPos = new Transform[4];
    [SerializeField] private GameObject _playerPrefab;

    private static float _timer = 0f;

    public static bool IsGodMode => _isGodMode;
    public static float Timer { get => _timer; set => _timer = value; }

    private void Awake()
    {
        _timer = Define.GAME_TIME;
        //TODO：Playerを、設定したスポーン位置の内のいずれかにランダムで生成する
        //Instantiate(_playerPrefab, _spawnPos[Random.Range(0, _spawnPos.Length)]);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0f)
        {
            //TODO：制限時間が0になった時に勝利判定をしてリザルトに遷移
            _fadeObject.StartFadeOut();
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
}
