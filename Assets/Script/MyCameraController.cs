using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour {

    private GameObject unitychan;
    private float difference;
	// Use this for initialization
	void Start () {
        this.unitychan = GameObject.Find("unitychan");
        //ユニティちゃんとカメラの位置（Z軸）の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        //ユニティちゃんの移動に合わせてカメラ位置を変更
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
		
	}
}
