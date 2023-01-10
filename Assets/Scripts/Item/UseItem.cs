using Consts;
using UnityEngine;

namespace Item
{
    public static class UseItem
    {
        private const int _healValue = 5;

        public static void StealthItem(GameObject go)
        {
            //↓Playerをステルス状態にする
            go.tag = Define.STEALTH_TAG;
            //↓視覚的なステルス状態(透明度を半分まで落とす)
            float alpha = 1f;
            Color color = go.GetComponent<MeshRenderer>().material.color;
            alpha /= 2f;

            color.a = alpha;
            go.GetComponent<MeshRenderer>().material.color = color;
        }

        public static void HealItem(GameObject go)
        {
            var health = go.GetComponent<PlayerController>().Health;

            health.HP += _healValue;

            if (health.HP >= health.MaxHp)
            {
                health.HP = health.MaxHp;
            }
        }

        public static void StatusUpItem(GameObject go, int item)
        {
            switch (item)
            {
                case 1:
                    //TODO：Playerの移動速度up
                    break;
                case 2:
                    //TODO：Playerのジャンプ力up
                    break;
                case 3:
                    //TODO：PlayerのHP上限up -> UIに反映
                    break;
                case 4:
                    //ハズレ?(ex.制限時間down)
                    break;
            }
        }
    }
}
