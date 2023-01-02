using Consts;
using UnityEngine;

public class HealItem : ItemBase
{
    [SerializeField] private int _healValue = 1;

    protected override void UseItem(GameObject go)
    {
        //PlayerHealth.HP += _healValue;

        //最大値を越えないようにする
        //if (PlayerHealth.HP >= PlayerHealth.MaxHp)
        //{
        //    PlayerHealth.HP = PlayerHealth.MaxHp;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Define.PLAYER_TAG))
        {
            ItemBox.AddToList(gameObject);
        }
    }
}
