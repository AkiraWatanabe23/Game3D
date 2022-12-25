using Consts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaders : MonoBehaviour
{
    public static void LoadTitle()
    {
        SceneManager.LoadScene(Define.TITLE_NAME);
    }

    public static void LoadInGame()
    {
        SceneManager.LoadScene(Define.INGAME_NAME);
    }

    public static void LoadResult()
    {
        SceneManager.LoadScene(Define.RESULT_NAME);
    }
}
