using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    private ItemBase _base;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    /// <summary>
    /// アイテムを捨て、Listから削除する
    /// </summary>
    private void DisposeItem(GameObject item)
    {
        _base.ItemList.Remove(item);
    }
}
