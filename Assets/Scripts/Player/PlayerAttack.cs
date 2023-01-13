using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAttack
{
    [Header("攻撃系Status")]
    [SerializeField] private int _attackValue = 5;
    [SerializeField] private Transform _muzzle = default;

    public int AttackValue => _attackValue;

    public void Init()
    {

    }

    public void Update()
    {
        //TODO：攻撃処理(銃)
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(_muzzle.position, _muzzle.forward, out RaycastHit hit, 10))
            {
                var point = hit.collider.gameObject;
                Debug.Log($"Hit {point.name}");
            }
        }
    }
}
