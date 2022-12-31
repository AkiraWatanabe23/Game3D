using UnityEngine;

[System.Serializable]
public class PlayerHealth
{
    [Header("体力系ステータス")]
    [SerializeField] private int _hp = 100;

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
