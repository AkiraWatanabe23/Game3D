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
    /// �A�C�e�����̂āAList����폜����
    /// </summary>
    private void DisposeItem(GameObject item)
    {
        _base.ItemList.Remove(item);
    }
}
