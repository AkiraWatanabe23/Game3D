using Consts;
using UnityEngine;

public class ToNextFloor : MonoBehaviour
{
    [SerializeField] private SceneNames _scene = default;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Define.PLAYER_TAG) ||
            other.CompareTag(Define.STEALTH_TAG))
        {
            SceneLoaders.PassToLoad(Define.Scenes[_scene]);
        }
    }
}
