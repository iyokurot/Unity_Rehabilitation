using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Block : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {
        // Observable.Interval (TimeSpan.FromMilliseconds (1000)).Subscribe (l => {
        //     fall ();
        // }).AddTo (this);
    }

    public void fall () {
        Vector3 pos = transform.position;
        pos.y += -1.0f;
        transform.position = pos;
    }

    public void MoveSide (bool right) {
        int direction = right ? 1 : -1;
        Vector3 pos = transform.position;
        pos.x += 1.0f * direction;
        transform.position = pos;
    }
}