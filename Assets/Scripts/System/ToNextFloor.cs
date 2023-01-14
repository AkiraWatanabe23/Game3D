using Consts;
using UnityEngine;

public class ToNextFloor : MonoBehaviour
{
    [SerializeField] private SceneNames _scene = default;

    private void OnTriggerEnter(Collider other)
    {
        SceneLoaders.PassToLoad
                (Define.Scenes[_scene]);
    }
}
