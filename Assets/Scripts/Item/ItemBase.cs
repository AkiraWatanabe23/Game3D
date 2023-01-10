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
        //この状態だと、ステルス状態でアイテムの取得ができない(ルール検討)
        if (other.gameObject.CompareTag(Define.PLAYER_TAG))
        {
            ItemBox.AddToList(gameObject);
        }
    }
}
