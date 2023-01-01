using Consts;
using UnityEngine;

public class HealItem : ItemBase
{
    [SerializeField] private int _healValue = 1;

    protected override void TouchPlayer(GameObject go)
    {
        PlayerHealth.HP += _healValue;

        //Å‘å’l‚ð‰z‚¦‚È‚¢‚æ‚¤‚É‚·‚é
        if (PlayerHealth.HP >= PlayerHealth.MaxHp)
        {
            PlayerHealth.HP = PlayerHealth.MaxHp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Define.PLAYER_TAG))
        {
            TouchPlayer(other.gameObject);
            gameObject.SetActive(false);
        }
    }
}
