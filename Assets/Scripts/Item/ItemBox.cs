using Consts;
using Item;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    //TODO：アイテムのプレハブをつくり、以下の配列に入れる
    [Tooltip("アイテムの種類")]
    [SerializeField] private GameObject[] _items = new GameObject[3];
    [Tooltip("Inspectorで確認する用のアイテムボックス")]
    [SerializeField] private List<GameObject> _itemList = new();

    [Header("テスト用")]
    [SerializeField] private Image _itemPanel;

    private static ItemBox _instance = default;

    public List<GameObject> ItemList { get => _itemList; set => _itemList = value; }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        //テスト用(アイテム削除)
        if (Input.GetKeyDown(KeyCode.C))
        {
            DisposeToList(_itemList[0]);
        }
        //テスト用(アイテム使用)
        if (Input.GetKeyDown(KeyCode.U))
        {
            _itemPanel.gameObject.SetActive(true);
        }
    }

    public static void AddToList(GameObject item)
    {
        if (_instance.ItemList.Count <= Define.ITEM_LIST_LIMIT)
        {
            _instance.ItemList.Add(item);
            item.SetActive(false);
            Debug.Log($"{item.name} をアイテムボックスに追加しました。");
        }
        else
        {
            Debug.Log("リストが上限に達しているため、アイテムを追加できません。");
        }
    }

    public static void DisposeToList(GameObject item)
    {
        if (_instance.ItemList?.Count > 0)
        {
            _instance.ItemList.Remove(item);
            Debug.Log($"{item.name} をアイテムボックスから削除しました。");
        }
        else
        {
            Debug.LogWarning("アイテムボックスが空です。");
        }
    }

    /// <summary>
    /// UIでアイテムを選択したときに実行する
    /// </summary>
    /// <param name="item"> アイテムの種類 </param>
    public void ConsumeItem(int item)
    {
        var parent = gameObject.transform.parent.gameObject;
        GameObject useItem = null;

        if (_itemList?.Count > 0)
        {
            //アイテムを使うとき、以下の処理を呼び出す(テスト)
            switch (item)
            {
                case 1:
                    UseItem.StealthItem(parent);
                    useItem = _items[0];
                    break;
                case 2:
                    UseItem.HealItem(parent);
                    useItem = _items[1];
                    break;
                case 3:
                    //UseItem.StatusUpItem(parent, );
                    useItem = _items[2];
                    break;
            }
            _itemList.Remove(useItem);
            Debug.Log($"{useItem.name} を使用し、アイテムボックスから消費します。");
        }
        else
        {
            Debug.LogWarning("アイテムボックスが空です。");
        }
    }
}
