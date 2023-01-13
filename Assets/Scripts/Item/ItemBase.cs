using Consts;
using UnityEngine;

/// <summary>
/// アイテムのクラス(入手したらボックスに追加)
/// 使用等の処理はアイテムボックスに記述
/// </summary>
public class ItemBase : MonoBehaviour
{
    [SerializeField] private ItemType _type = default;

    public ItemType Type => _type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Define.PLAYER_TAG) || 
            other.gameObject.CompareTag(Define.STEALTH_TAG))
        {
            ItemBox.AddToList((int)_type);
            Debug.Log($"{gameObject.name} をリストに追加しました。");
            Destroy(gameObject);
        }
    }
}
