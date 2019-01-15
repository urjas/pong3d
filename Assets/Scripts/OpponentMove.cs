using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentMove : MonoBehaviour {

    private Transform ball;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z - ball.transform.position.z>5) {
            transform.position = new Vector3(ball.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
