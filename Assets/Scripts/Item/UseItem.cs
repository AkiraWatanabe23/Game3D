using Consts;
using UnityEngine;

namespace Item
{
    public static class UseItem
    {
        private const int _healValue = 5;

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
            var health = go.GetComponent<PlayerController>().Health;

            health.HP += _healValue;

            if (health.HP >= health.MaxHp)
            {
                health.HP = health.MaxHp;
            }
        }

        public static void StatusUpItem(GameObject go, StatusType item)
        {
            //�X�e�[�^�X�����コ����(�e�X�g)
            if (item == StatusType.MOVE)
            {
                //TODO�FPlayer�̈ړ����xup
            }
            else if (item == StatusType.JUMP)
            {
                //TODO�FPlayer�̃W�����v��up
            }
            else if (item == StatusType.HP)
            {
                //TODO�FPlayer��HP���up -> UI�ɔ��f
            }
        }

        public enum StatusType
        {
            DEFAULT,
            /// <summary> �ړ����xup </summary>
            MOVE,
            /// <summary> �W�����v��up </summary>
            JUMP,
            /// <summary> HP���up </summary>
            HP,
        }
    }
}
