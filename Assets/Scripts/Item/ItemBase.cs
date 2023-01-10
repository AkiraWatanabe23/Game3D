using Consts;
using UnityEngine;

/// <summary>
/// アイテムの基底クラス(入手したらボックスに追加)
/// 使用等の処理はアイテムボックスに記述
/// </summary>
public class ItemBase : MonoBehaviour
{
    [SerializeField] private ItemType _type = ItemType.DEFAULT;

    public ItemType Type => _type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Define.PLAYER_TAG) || 
            other.gameObject.CompareTag(Define.STEALTH_TAG))
        {
            //ItemBox.AddToList(gameObject);
            ItemBox.AddToList((int)_type - 1);
            gameObject.SetActive(false);
            Debug.Log($"{gameObject.name} をアイテムボックスに追加しました。");
        }
    }
}
