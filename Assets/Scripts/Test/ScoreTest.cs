using Consts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreTest : MonoBehaviour
{
    [SerializeField] private Text _scoreText = default;
    [SerializeField] private Text _highScoreText = default;

    private int _score = 0;
    private int _highScore = 0;

    private void Awake()
    {
        //if (SceneManager.GetActiveScene().name ==
        //    Define.Scenes[SceneNames.FF_SCENE])
        //{
        //    _score = PlayerPrefs.GetInt("Score", 0);
        //    _highScore = PlayerPrefs.GetInt("HighScore", 0);

        //    Debug.Log($"開始時のスコアは {_score} です");
        //    Debug.Log($"現在のハイスコアは {_highScore} です");
        //}
        _score = PlayerPrefs.GetInt("Score", 0);
        _highScore = PlayerPrefs.GetInt("HighScore", 0);

        Debug.Log($"開始時のスコアは {_score} です");
        Debug.Log($"現在のハイスコアは {_highScore} です");
    }

    private void Update()
    {
        _scoreText.text = "SCORE : " + _score.ToString("F0");
        _highScoreText.text = "HIGH SCORE : " + _highScore.ToString("F0");

        _score += 2;
    }

    private void OnDestroy()
    {
        //ハイスコアが更新されたら反映する(resultに入ったタイミングで行う)
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore", _highScore);
        }
        //スコアをリセット、セーブする(実際は、result->titleのときとかに使う)
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.Save();
    }
}
