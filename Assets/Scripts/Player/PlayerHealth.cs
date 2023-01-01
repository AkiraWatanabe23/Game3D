using UnityEngine;

[System.Serializable]
public class PlayerHealth
{
    [Header("体力系ステータス")]
    [SerializeField] private static int _hp = 100;

    private static int _maxHp = 0;

    public static int HP { get => _hp; set => _hp = value; }
    public static int MaxHp { get => _maxHp; set => _maxHp = value; }

    public void Init()
    {
        _maxHp = _hp;
    }

    public void Update()
    {

    }

    public void Damage(int damage)
    {
        _hp -= damage;
    }
}
