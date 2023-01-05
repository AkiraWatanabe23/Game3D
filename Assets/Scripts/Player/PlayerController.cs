using UnityEngine;

/// <summary>
/// Playerの各機能をまとめたもの
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMove _movements = default;
    [SerializeField] private PlayerHealth _health = default;

    public PlayerMove Movements => _movements;
    public PlayerHealth Health => _health;

    private void Awake()
    {
        var rb = GetComponent<Rigidbody>();

        _movements.Init(transform, rb);
        _health.Init();
    }

    private void Update()
    {
        _health.Update();
    }

    private void FixedUpdate()
    {
        _movements.FixedUpdate();
    }
}
