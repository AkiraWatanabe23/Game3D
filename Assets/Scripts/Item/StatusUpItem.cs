using Consts;
using UnityEngine;

public class StatusUpItem : ItemBase
{
    [SerializeField] private StatusType _status = StatusType.DEFAULT;

    protected override void TouchPlayer(GameObject go)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Define.PLAYER_TAG))
        {
            TouchPlayer(other.gameObject);
            gameObject.SetActive(false);
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
