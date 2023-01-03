using Consts;
using UnityEngine;

/// <summary>
/// Playerをステルス状態にして敵に見つからなくする
/// </summary>
public class StealthItem : ItemBase
{
    private float _stealthTime = 1f;

    private void Update()
    {
        if (_stealthTime >= ValidTime)
        {
            //一定時間経ったらステルス状態を解除する
        }
    }

    protected override void UseItem(GameObject go)
    {
        go.tag = Define.STEALTH_TAG;
        //視覚的なステルス状態
        float alpha = 1f;
        Color color = go.GetComponent<MeshRenderer>().material.color;
        alpha /= 2f;

        color.a = alpha;
        go.GetComponent<MeshRenderer>().material.color = color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Define.PLAYER_TAG))
        {
            ItemBox.AddToList(gameObject);
        }
    }
}
