using Consts;
using UnityEngine;

/// <summary>
/// Playerのステータスを向上させるアイテム
/// </summary>
[System.Serializable]
public class StatusUpItem
{
    [SerializeField] private StatusType _status = StatusType.DEFAULT;

    public void UseItem(GameObject go)
    {
        //ステータスを向上させる(テスト)
        if (_status == StatusType.MOVE)
        {
            //PlayerMove.MoveSpeed += 5;
        }
        else if (_status == StatusType.JUMP)
        {
            //PlayerMove.JumpPower += 5;
        }
        else if (_status == StatusType.HP)
        {
            //PlayerHealth.MaxHp += 10;
        }
    }

    public enum StatusType
    {
        DEFAULT,
        /// <summary> 移動速度UP </summary>
        MOVE,
        /// <summary> ジャンプ力UP </summary>
        JUMP,
        /// <summary> HP上限UP </summary>
        HP,
    }
}
