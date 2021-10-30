using System.Collections;
using System.Collections.Generic;
// using UnityEngine;
public class DefScene {
    const int SCENE_NO_TOP = 1;
    const int SCENE_NO_3DSCENE = 2;
    const int SCENE_NO_TETRIS = 3;

    static readonly Dictionary<int, string> SCENE_LIST = new Dictionary<int, string> () { { SCENE_NO_TOP, "TOP" }, { SCENE_NO_3DSCENE, "3DScene" }, { SCENE_NO_TETRIS, "Tetris" }
    };

    public static string getSceneNameByNo (int sceneNo) {
        string sceneName = SCENE_LIST[sceneNo];
        return sceneName;
    }
}