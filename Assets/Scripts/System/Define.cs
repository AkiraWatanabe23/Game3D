using System.Collections.Generic;
using UnityEngine;

namespace Consts
{
    public static class Define
    {
        //数値関連の定数
        public const int ITEM_LIST_LIMIT = 20;
        public const float GAME_TIME = 10f;

        //タグ名
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
    }

    /// <summary>
    /// シーン名のenum
    /// </summary>
    public enum SceneNames
    {
        TITLE_SCENE,
        FF_SCENE,
        FB_SCENE,
        SB_SCENE,
        RESULT_SCENE,
    }

    public enum ItemType
    {
        STEALTH,
        HEAL,
        STATUSUP,
    }
}
