using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class TetrisGameController : MonoBehaviour {
    [SerializeField]
    List<GameObject> blockObjectList;

    private List<GameObject> targetBlockObjectList;

    private float time = 0;
    // Start is called before the first frame update
    void Start () {

        /* 以下テストよう */
        // ブロックを一定間隔で配置
        targetBlockObjectList = new List<GameObject> ();
        int blockCount = 0;
        foreach (GameObject targetBlock in blockObjectList) {
            float x = (blockCount / 3) * 4.0f;
            float y = (blockCount % 3) * 4.0f;
            GameObject createBlock = Instantiate (targetBlock, new Vector3 (x, y, 0), Quaternion.identity);
            targetBlockObjectList.Add (createBlock);
            blockCount++;
        }

        // 一定間隔で処理
        Observable.Interval (TimeSpan.FromMilliseconds (5000)).Subscribe (l => {
            // Debug.Log ("time");
        }).AddTo (this);

        // ボタン判定
        Observable.EveryUpdate ()
            .Where (_ => Input.GetKey (KeyCode.DownArrow))
            .ThrottleFirst (TimeSpan.FromMilliseconds (100), Scheduler.MainThread)
            .Subscribe (_ => {
                foreach (GameObject block in targetBlockObjectList) {
                    SpinObject (block);
                }
            });
        Observable.EveryUpdate ()
            .Where (_ => Input.GetKey (KeyCode.UpArrow))
            .ThrottleFirst (TimeSpan.FromMilliseconds (100), Scheduler.MainThread)
            .Subscribe (_ => {
                foreach (GameObject block in targetBlockObjectList) {
                    SpinReverseObject (block);
                }
            });
        Observable.EveryUpdate ()
            .Where (_ => Input.GetKey (KeyCode.RightArrow))
            .ThrottleFirst (TimeSpan.FromMilliseconds (100), Scheduler.MainThread)
            .Subscribe (_ => {
                foreach (GameObject block in targetBlockObjectList) {
                    Block script = block.GetComponent<Block> ();
                    script.MoveSide (true);
                }
            });
        Observable.EveryUpdate ()
            .Where (_ => Input.GetKey (KeyCode.LeftArrow))
            .ThrottleFirst (TimeSpan.FromMilliseconds (100), Scheduler.MainThread)
            .Subscribe (_ => {
                foreach (GameObject block in targetBlockObjectList) {
                    Block script = block.GetComponent<Block> ();
                    script.MoveSide (false);
                }
            });
        Observable.EveryUpdate ()
            .Where (_ => Input.GetKey (KeyCode.Space))
            .ThrottleFirst (TimeSpan.FromMilliseconds (100), Scheduler.MainThread)
            .Subscribe (_ => {
                foreach (GameObject block in targetBlockObjectList) {
                    Block script = block.GetComponent<Block> ();
                    script.fall ();
                }
            });
    }

    // Update is called once per frame
    void Update () { }

    private void SpinObject (GameObject blockObj) {
        blockObj.transform.Rotate (new Vector3 (0, 0, 90));
    }
    private void SpinReverseObject (GameObject blockObj) {
        blockObj.transform.Rotate (new Vector3 (0, 0, -90));
    }
}