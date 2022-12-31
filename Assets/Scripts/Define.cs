using System.Collections.Generic;
using UnityEngine;

namespace Consts
{
    public static class Define
    {
        public const float GAME_TIME = 10f;
        public static readonly Dictionary<SceneNames, string> Scenes = new()
        {
            [SceneNames.TITLE_NAME] = "TitleScene",
            [SceneNames.INGAME_NAME] = "MainGameScene",
            [SceneNames.RESULT_NAME] = "ResultScene",
        };
    }

    public enum SceneNames
    {
        TITLE_NAME,
        INGAME_NAME,
        RESULT_NAME
    }
}
