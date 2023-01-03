using Consts;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムの基底クラス
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    [Tooltip("効果の有効時間")]
    [SerializeField] private float _validTime = 0f;

    private Rigidbody _rb;

    public float ValidTime => _validTime;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// アイテムを使用するときに実行する関数
    /// </summary>
    protected abstract void UseItem(GameObject go);
}
