using Consts;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムの基底クラス
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// アイテムを使用するときに実行する関数
    /// </summary>
    protected abstract void UseItem(GameObject go);
}
