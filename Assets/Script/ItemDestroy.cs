using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour {

    private GameObject mainCamera;
    private Vector3 cameraPos;


	// Use this for initialization
	void Start () {
        this.mainCamera = GameObject.Find("Main Camera");
       
	}
	
	// Update is called once per frame
	void Update () {
        this.cameraPos = mainCamera.transform.position;
        if(this.gameObject.transform.position.z < this.cameraPos.z)
        {
            Destroy(gameObject);
            Debug.Log("Destroy");
        }
		
	}
}
