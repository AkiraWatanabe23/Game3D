using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("ステータス一覧")]
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _jumpPower = 1f;
    [SerializeField] private bool _isGround = false;

    private Rigidbody _rb;

    private void Start()
    {
        _isGround = true;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float hol = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        float y = _rb.velocity.y;
        if (Input.GetButtonDown("Jump") && _isGround)
        {
            y = _jumpPower;
            _isGround = false;
        }

        _rb.velocity = 
            new Vector3(hol * _moveSpeed, 0, ver * _moveSpeed) + Vector3.up * y;
    }

    private void OnTriggerEnter(Collider other)
    {
        _isGround = true;
    }
}
