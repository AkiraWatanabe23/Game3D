using Consts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Tooltip("Playerの初期位置をランダムで決める")]
    [SerializeField] private List<Transform> _playerSpawn = new();
    [SerializeField] private GameObject _player;

    private static bool _isPause = false;
    private static float _timer = Define.GAME_TIME;

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
        //Playerを設定したスポーン位置の内のいずれかにランダムで出現する
        if (_playerSpawn.Count > 0 && _player)
        {
            _player.transform.position = _playerSpawn[Random.Range(0, _playerSpawn.Count)].transform.position;
        }
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
    }
}