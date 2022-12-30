using UnityEngine.SceneManagement;

/// <summary>
/// 指定したシーンに遷移する(フェード後)
/// </summary>
public class SceneLoaders
{
    //シーン名を引数に渡し、遷移する
    public static void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
