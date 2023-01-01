using Consts;
using UnityEngine;

/// <summary>
/// Playerをステルス状態にして敵に見つからなくする
/// </summary>
public class StealthItem : ItemBase
{
    private void Start()
    {
        
    }

    private void Update()
    {

    }

    protected override void TouchPlayer(GameObject go)
    {
        go.tag = Define.STEALTH_TAG;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Define.PLAYER_TAG))
        {
            TouchPlayer(other.gameObject);
            gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag(Define.PLAYER_TAG))
        {
            AddToList(gameObject);
        }
    }
}
