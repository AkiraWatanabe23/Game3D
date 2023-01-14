using Consts;
using UnityEngine;

[System.Serializable]
public class EnemyAttack
{
    [SerializeField] private int _attackValue = 10;

    public int AttackValue { get=> _attackValue; set => _attackValue = value; }

    public void Init()
    {
        
    }

    public void Update()
    {

    }

    public void OnCollisionEnter(Collision col)
    {
        //TODO：攻撃処理
        if (col.gameObject.CompareTag(Define.PLAYER_TAG))
        {

        }
    }
}
