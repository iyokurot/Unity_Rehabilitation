using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopSceneManager : MonoBehaviour {
    private bool isChangeScene = false;
    // Start is called before the first frame update
    void Start () {

    }

    /**
    シーン遷移を行う
    遷移先は番号で指定(DefScene)
     */
    public void sceneChange (int sceneNo) {
        // 処理中は他のシーン遷移を反応なしにする
        if (isChangeScene) { return; }
        isChangeScene = true;
        // Debug.Log ("change scene! " + sceneNo);
        string sceneName = DefScene.getSceneNameByNo (sceneNo);
        // 遷移アニメーション
        SceneManager.LoadSceneAsync (sceneName);
    }
}