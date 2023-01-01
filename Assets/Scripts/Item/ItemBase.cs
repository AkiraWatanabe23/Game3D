using System.Collections;
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

    private void Update()
    {
        
    }

    /// <summary>
    /// アイテムがPlayerに接触した時に実行する関数
    /// </summary>
    protected abstract void TouchPlayer();

    private void OnTriggerEnter(Collider other)
    {
        TouchPlayer();
        gameObject.SetActive(false);
    }
}
