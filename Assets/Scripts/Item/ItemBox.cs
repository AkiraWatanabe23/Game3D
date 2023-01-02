using Consts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] private List<GameObject> _itemList = new();

    private static ItemBox _instance = default;

    public List<GameObject> ItemList { get => _itemList; set => _itemList = value; }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    //TODO：アイテムを取得した時、リストが上限に達してなければ追加
    public static void AddToList(GameObject item)
    {
        if (_instance.ItemList.Count <= Define.ITEM_LIST_LIMIT)
        {
            _instance.ItemList.Add(item);
            item.SetActive(false);
        }
        else
        {
            Debug.Log("リストが上限に達しているため、アイテムを追加できません。");
        }
    }

    /// <summary>
    /// アイテムを捨て、Listから削除する
    /// </summary>
    public void DisposeToList(GameObject item)
    {
        _itemList.Remove(item);
    }

    /// <summary>
    /// 選んだアイテムを使い、Listから削除する
    /// </summary>
    public void UseItem(GameObject item)
    {
        //TODO：ここでアイテムを使用する関数を実行
        _itemList.Remove(item);
    }
}
