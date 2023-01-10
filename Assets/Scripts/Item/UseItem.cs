using Consts;
using UnityEngine;

namespace Item
{
    public static class UseItem
    {
        public static void StealthItem(GameObject go)
        {
            //��Player���X�e���X��Ԃɂ���
            go.tag = Define.STEALTH_TAG;
            //�����o�I�ȃX�e���X���(�����x�𔼕��܂ŗ��Ƃ�)
            float alpha = 1f;
            Color color = go.GetComponent<MeshRenderer>().material.color;
            alpha /= 2f;

            color.a = alpha;
            go.GetComponent<MeshRenderer>().material.color = color;
        }

        public static void HealItem(GameObject go)
        {
            int healValue = Random.Range(5, 16);
            var health = go.GetComponent<PlayerController>().Health;
            //��Player�̗̑͂��񕜂���
            health.HP += healValue;

            if (health.HP >= health.MaxHp)
            {
                health.HP = health.MaxHp;
            }
            Debug.Log($"Player�̗̑͂� {healValue} �񕜂��܂����B");
        }

        public static void StatusUpItem(GameObject go, int item)
        {
            switch (item)
            {
                case 1:
                    //TODO�FPlayer�̈ړ����xup
                    break;
                case 2:
                    //TODO�FPlayer�̃W�����v��up
                    break;
                case 3:
                    //TODO�FPlayer��HP���up -> UI�ɔ��f
                    break;
                case 4:
                    //�n�Y��?(ex.��������down)
                    break;
            }
        }
    }
}
