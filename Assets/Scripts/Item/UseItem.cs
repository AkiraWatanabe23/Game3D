using Consts;
using UnityEngine;

namespace Item
{
    public static class UseItem
    {
        //アイテム使うときにエフェクトとかあったら分かりやすいかも?
        public static void StealthItem(GameObject go)
        {
            var itemBox = go.GetComponentInChildren<ItemBox>();
            //↓Playerをステルス状態にする
            go.tag = Define.STEALTH_TAG;
            //↓視覚的なステルス状態(透明度を半分まで落とす)
            float alpha = 1f;
            Color color = go.GetComponent<MeshRenderer>().material.color;
            alpha /= 2f;

            color.a = alpha;
            go.GetComponent<MeshRenderer>().material.color = color;

            itemBox.IsUsing = true;
        }

        public static void HealItem(GameObject go)
        {
            int healValue = Random.Range(5, 16);
            var health = go.GetComponent<PlayerController>().Health;
            //↓Playerの体力を回復する
            health.HP += healValue;

            if (health.HP >= health.MaxHp)
            {
                health.HP = health.MaxHp;
            }
            Debug.Log($"Playerの体力を {healValue} 回復しました。");
        }

        public static void StatusUpItem(GameObject go, int item)
        {
            var itemBox = go.GetComponentInChildren<ItemBox>();
            int riseValue = Random.Range(5, 11);

            //どのステータスがUPするかはランダムで決まる
            //ステータス上昇中かどうかが、視覚的(UI等)に分かりやすい方が良い
            switch (item)
            {
                case 1:
                case 2:
                    //Playerの移動系能力up
                    var move = go.GetComponent<PlayerController>().Movements;

                    itemBox.UpValue = riseValue;
                    move.MoveSpeed += riseValue;
                    move.JumpPower += riseValue;
                    break;
                case 3:
                    //PlayerのHP上限up -> UIに反映
                    var health = go.GetComponent<PlayerController>().Health;
                    health.MaxHp += riseValue;
                    //TODO：sliderのmaxValueに反映させる
                    break;
                case 4:
                    //ハズレ?(ex.制限時間down)
                    GameManager.Timer -= 5f;
                    break;
            }
            itemBox.StatusNum = item;
            itemBox.IsUsing = true;
        }
    }
}
