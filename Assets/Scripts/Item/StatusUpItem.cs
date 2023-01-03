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
            //TODO：Playerの移動速度up
        }
        else if (_status == StatusType.JUMP)
        {
            //TODO：Playerのジャンプ力up
        }
        else if (_status == StatusType.HP)
        {
            //TODO：PlayerのHP上限up -> UIに反映
        }
    }

    public enum StatusType
    {
        DEFAULT,
        /// <summary> 移動速度up </summary>
        MOVE,
        /// <summary> ジャンプ力up </summary>
        JUMP,
        /// <summary> HP上限up </summary>
        HP,
    }
}
