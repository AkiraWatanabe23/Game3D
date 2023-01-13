using UnityEngine;

/// <summary> Playerの各機能をまとめたもの </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMove _movements = default;
    [SerializeField] private PlayerHealth _health = default;
    [SerializeField] private PlayerAttack _attack = default;

    public PlayerMove Movements => _movements;
    public PlayerHealth Health => _health;
    public PlayerAttack Attack => _attack;

    private void Awake()
    {
        var rb = GetComponent<Rigidbody>();

        _movements.Init(transform, rb);
        _health.Init();
        _attack.Init();
    }

    private void Update()
    {
        _movements.Update();
        _health.Update();
        _attack.Update();
    }

    private void FixedUpdate()
    {
        _movements.FixedUpdate();
    }

    //UIで扱うPause処理
    public void Pause()
    {
        _movements.IsPause = true;
    }

    public void Resume()
    {
        _movements.IsPause = false;
    }
}
