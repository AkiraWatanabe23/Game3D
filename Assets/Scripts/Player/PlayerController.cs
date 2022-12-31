using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player‚ÌŠe‹@”\‚ð‚Ü‚Æ‚ß‚½‚à‚Ì
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMove _movements = default;
    [SerializeField] private PlayerHealth _health = default;

    private void Start()
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
}
