using Consts;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムの基底クラス
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    private Rigidbody _rb;
    private List<GameObject> _itemList = new();

    public List<GameObject> ItemList { get => _itemList; set => _itemList = value; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    //TODO：アイテムを取得した時、リストが上限に達してなければ追加
    public void AddToList(GameObject item)
    {
        if (_itemList.Count <= Define.ITEM_LIST_LIMIT)
        {
            _itemList.Add(item);
            item.SetActive(false);
        }
        else
        {
            Debug.Log("リストが上限に達しているため、アイテムを追加できません。");
        }
    }

    /// <summary>
    /// アイテムがPlayerに接触した時に実行する関数
    /// </summary>
    protected abstract void TouchPlayer(GameObject go);
}
