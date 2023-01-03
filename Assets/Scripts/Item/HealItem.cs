using Consts;
using UnityEngine;

/// <summary>
/// Playerの体力を回復するアイテム
/// </summary>
[System.Serializable]
public class HealItem
{
    [SerializeField] private int _healValue = 1;

    public void UseItem(GameObject go)
    {
        //PlayerHealth.HP += _healValue;

        //最大値を越えないようにする
        //if (PlayerHealth.HP >= PlayerHealth.MaxHp)
        //{
        //    PlayerHealth.HP = PlayerHealth.MaxHp;
        //}
    }
}
