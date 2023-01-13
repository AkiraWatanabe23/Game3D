using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAttack
{
    [Header("攻撃系Status")]
    [SerializeField] private int _attackValue = 5;

    public int AttackValue => _attackValue;

    public void Init()
    {

    }

    public void Update()
    {
        //TODO：攻撃処理(攻撃の種類によるため、検討)
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("attack");
        }
    }
}
