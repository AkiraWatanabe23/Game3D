using Consts;
using Item;
using System.Collections;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    [SerializeField] private GameObject[] _items = new GameObject[3];
    [SerializeField] private int[] _itemCount = new int[3];

    public void AddToList(int item)
    {
        if (_itemCount[0] + _itemCount[1] + _itemCount[2] <= Define.ITEM_LIST_LIMIT)
        {
            _itemCount[item]++;
            //ItemList.Add(item);
        }
        else
        {
            Debug.Log("リストが上限に達しているため、アイテムを追加できません。");
        }
    }

    public void DisposeToList(GameObject item)
    {
        var num = item.GetComponent<ItemBase>().Type;
        if (_itemCount[(int)num] > 0)
        {
            _itemCount[(int)num]--;
        }
        else
        {
            Debug.LogError("指定されたアイテムは既にリストにありません。");
        }

        //if (ItemList?.Count > 0)
        //{
        //    ItemList.Remove(item);
        //    Debug.Log($"{item.name} をアイテムボックスから削除しました。");
        //}
        //else
        //{
        //    Debug.LogError("指定されたアイテムは既にリストにありません。");
        //}
    }

    /// <summary>
    /// UIでアイテムを選択したときに実行する
    /// </summary>
    /// <param name="item"> アイテムの種類 </param>
    public void ConsumeItem(int item)
    {
        var parent = gameObject.transform.parent.gameObject;
        GameObject consume = _items[item];

        if (_itemCount[item] > 0)
        {
            //アイテムを使うとき、以下の処理を呼び出す
            switch (item)
            {
                case 0:
                    UseItem.StealthItem(parent);
                    break;
                case 1:
                    UseItem.HealItem(parent);
                    break;
                case 2:
                    UseItem.StatusUpItem(parent, Random.Range(1, 5));
                    break;
            }
            //_itemList.Remove(consume);
            _itemCount[item]--;
            Debug.Log($"{consume.name} を使用し、アイテムボックスから消費します。");
        }
        else
        {
            Debug.LogError("指定されたアイテムがありません。");
        }
    }
}
