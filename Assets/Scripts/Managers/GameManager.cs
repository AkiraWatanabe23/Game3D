using Consts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameClose();
        }
    }

    //�Q�[�����I������
    private void GameClose()
    {

#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
