using UnityEngine;

[System.Serializable]
public class EnemyAttack
{
    [SerializeField] private int _attackValue = 10;
    [SerializeField] private float _attackInterval = 5f;

    public int AttackValue { get=> _attackValue; set => _attackValue = value; }

    public void Init()
    {
        
    }

    public void Update()
    {
        if (GameManager.Timer >= _attackInterval)
        {
            //一定時間経ったらEnemyの攻撃
        }
    }
}
