using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    private float speed = 10f;

	
	// Update is called once per frame
	void Update () {
		 if (Input.GetKey(KeyCode.UpArrow)) {
            transform.position += Vector3.left * speed * Time.deltaTime;
         }
         if (Input.GetKey(KeyCode.DownArrow)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
         }
	}
}
