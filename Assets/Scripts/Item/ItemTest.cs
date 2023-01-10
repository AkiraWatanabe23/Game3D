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
            Debug.Log("���X�g������ɒB���Ă��邽�߁A�A�C�e����ǉ��ł��܂���B");
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
            Debug.LogError("�w�肳�ꂽ�A�C�e���͊��Ƀ��X�g�ɂ���܂���B");
        }

        //if (ItemList?.Count > 0)
        //{
        //    ItemList.Remove(item);
        //    Debug.Log($"{item.name} ���A�C�e���{�b�N�X����폜���܂����B");
        //}
        //else
        //{
        //    Debug.LogError("�w�肳�ꂽ�A�C�e���͊��Ƀ��X�g�ɂ���܂���B");
        //}
    }

    /// <summary>
    /// UI�ŃA�C�e����I�������Ƃ��Ɏ��s����
    /// </summary>
    /// <param name="item"> �A�C�e���̎�� </param>
    public void ConsumeItem(int item)
    {
        var parent = gameObject.transform.parent.gameObject;
        GameObject consume = _items[item];

        if (_itemCount[item] > 0)
        {
            //�A�C�e�����g���Ƃ��A�ȉ��̏������Ăяo��
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
            Debug.Log($"{consume.name} ���g�p���A�A�C�e���{�b�N�X�������܂��B");
        }
        else
        {
            Debug.LogError("�w�肳�ꂽ�A�C�e��������܂���B");
        }
    }
}
