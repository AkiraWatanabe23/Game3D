using Consts;
using UnityEngine;

/// <summary>
/// Player‚ğƒXƒeƒ‹ƒXó‘Ô‚É‚µ‚Ä“G‚ÉŒ©‚Â‚©‚ç‚È‚­‚·‚é
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
        else if (other.gameObject.CompareTag(Define.ITEM_TAG))
        {
            AddToList(gameObject);
        }
    }
}
