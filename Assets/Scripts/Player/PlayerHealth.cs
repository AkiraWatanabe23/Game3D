using UnityEngine;

[System.Serializable]
public class PlayerHealth
{
    [Header("体力系ステータス")]
    [SerializeField] private static int _hp = 100;

    public static int HP { get => _hp; set => _hp = value; }

    public void Init()
    {

    }

    public void Update()
    {
        
    }

    public void Damage(int damage)
    {
        _hp -= damage;
    }
}
