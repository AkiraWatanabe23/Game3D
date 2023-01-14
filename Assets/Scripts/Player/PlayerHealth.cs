using UnityEngine;

[System.Serializable]
public class PlayerHealth : IDamage
{
    [Header("体力系Status")]
    [SerializeField] private int _hp = 100;
    [SerializeField] private int _maxHp = 0;

    public int HP { get => _hp; set => _hp = value; }
    public int MaxHp { get => _maxHp; set => _maxHp = value; }

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
