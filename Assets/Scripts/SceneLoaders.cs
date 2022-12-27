using Consts;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 指定したシーンに遷移する(フェード後)
/// </summary>
public class SceneLoaders : MonoBehaviour
{
    public static void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //指定したシーンに遷移する関数(Title, InGame, Result)
    public static void LoadToTitle()
    {
        SceneManager.LoadScene(Define.TITLE_NAME);
    }

    public static void LoadToInGame()
    {
        SceneManager.LoadScene(Define.INGAME_NAME);
    }

    public static void LoadToResult()
    {
        SceneManager.LoadScene(Define.RESULT_NAME);
    }
}
