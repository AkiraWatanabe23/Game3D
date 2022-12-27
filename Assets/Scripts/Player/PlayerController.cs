using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("ステータス一覧")]
    [SerializeField] private float _moveSpeed = 1f;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float hol = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        _rb.velocity = new Vector3(hol * _moveSpeed, 0, ver * _moveSpeed);
    }
}
