using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの各機能をまとめたもの
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMove _movements = default;
    [SerializeField] private PlayerHealth _health = default;

    private void Awake()
    {
        var rb = GetComponent<Rigidbody>();
        _movements.Init(transform, rb);
        _health.Init();
    }

    private void Update()
    {
        _movements.Update();
        _health.Update();
    }
}
