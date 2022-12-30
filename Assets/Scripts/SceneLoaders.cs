using Consts;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 指定したシーンに遷移する
/// </summary>
public class SceneLoaders : MonoBehaviour
{
    private Fade _fade;

    private void Start()
    {
        _fade = GetComponent<Fade>();
    }

    //シーン名を引数に渡し、遷移する
    public static void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadToTitle()
    {
        _fade.StartFadeOut(() => SceneLoad(Define.TITLE_NAME));
    }

    public void LoadToInGame()
    {
        _fade.StartFadeOut(() => SceneLoad(Define.INGAME_NAME));
    }

    public void LoadToResult()
    {
        _fade.StartFadeOut(() => SceneLoad(Define.RESULT_NAME));
    }
}
