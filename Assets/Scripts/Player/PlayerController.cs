using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの各機能をまとめたもの
/// </summary>
public class PlayerController : MonoBehaviour, IPause
{
    [SerializeField] private PlayerMove _movements = default;
    [SerializeField] private PlayerHealth _health = default;

    private void Awake()
    {
        var rb = GetComponent<Rigidbody>();
        _movements.Init(rb);
        _health.Init();
    }

    private void Update()
    {
        _movements.Update();
        _health.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        _movements.OnTriggerEnter(other);
    }

    public void Pause()
    {
        //TODO：一時停止処理の記述
        //入力を切る
    }

    public void Resume()
    {
        //TODO：処理再開の記述
    }
}
