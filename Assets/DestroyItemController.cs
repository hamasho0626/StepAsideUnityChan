using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItemController : MonoBehaviour {

    private Camera MainCamera;

	// Use this for initialization
	void Start () {
        this.MainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        //対象のオブジェクトがカメラより手前にきたら削除する
        if(this.MainCamera.transform.position.z > this.transform.position.z)
        {
            Destroy(this.gameObject);
        }
		
	}

    
}