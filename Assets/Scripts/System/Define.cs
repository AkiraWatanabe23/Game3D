using System.Collections.Generic;
using UnityEngine;

namespace Consts
{
    public static class Define
    {
        //数値関連の定数
        public const int ITEM_LIST_LIMIT = 20;
        public const float GAME_TIME = 10f;

        //タグ名(使うもののみ)
        public const string PLAYER_TAG = "Player";
        public const string STEALTH_TAG = "Stealth";

        //シーン名をenumでまとめたDictionary(UIでのシーン遷移で使う)
        public static readonly Dictionary<SceneNames, string> Scenes = new()
        {
            [SceneNames.TITLE_SCENE] = "TitleScene",
            [SceneNames.FF_SCENE] = "FirstFloorScene",
            [SceneNames.FB_SCENE] = "FirstBasementScene",
            [SceneNames.SB_SCENE] = "SecondBasementScene",
            [SceneNames.RESULT_SCENE] = "ResultScene",
        };

        //コード内でAnimationを再生するのに使う
        public static readonly Dictionary<AnimType, string> Anims = new()
        {
            [AnimType.IDLE] = "Idle",
            [AnimType.MOVE] = "Move",
            [AnimType.JUMP] = "Jump",
            [AnimType.ATTACK] = "Attack",
            [AnimType.DAMAGE] = "Damage",
            [AnimType.DEAD] = "Dead",
        };
    }

    public enum SceneNames
    {
        TITLE_SCENE,
        FF_SCENE,
        FB_SCENE,
        SB_SCENE,
        RESULT_SCENE,
    }

    public enum AnimType
    {
        IDLE,
        MOVE,
        JUMP,
        ATTACK,
        DAMAGE,
        DEAD,
    }

    public enum ItemType
    {
        STEALTH,
        HEAL,
        STATUSUP,
    }
}
