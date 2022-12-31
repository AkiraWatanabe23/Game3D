using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの各機能をまとめたもの
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMove _movements = default;

    private void Start()
    {
        var rb = GetComponent<Rigidbody>();
        _movements.Init(rb);
    }

    private void Update()
    {
        _movements.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        _movements.OnTriggerEnter(other);
    }
}
