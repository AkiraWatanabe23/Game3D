using UnityEngine;

/// <summary> Playerの各機能をまとめたもの </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMove _movement = default;
    [SerializeField] private PlayerHealth _health = default;

    public PlayerMove Movements => _movement;
    public PlayerHealth Health => _health;

    private void Awake()
    {
        var rb = GetComponent<Rigidbody>();

        _movement.Init(transform, rb);
        _health.Init();
    }

    private void Update()
    {
        _movement.Update();
        _health.Update();
    }

    private void FixedUpdate()
    {
        _movement.FixedUpdate();
    }

    //UIで扱うPause処理
    public void Pause()
    {
        _movement.IsPause = true;
    }

    public void Resume()
    {
        _movement.IsPause = false;
    }
}
