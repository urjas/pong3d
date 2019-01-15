using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMove : MonoBehaviour {
	private Rigidbody rb;
	int speed = 100;
    int player1Score, player2Score;

    [SerializeField]
    Text Player1ScoreText, Player2ScoreText;


    private Vector3 resetPos;
		// Use this for initialization
	void Start () {
        player1Score = 0;
        player2Score = 0;
        rb = GetComponent<Rigidbody>();
		resetPos = transform.position;
		StartCoroutine("Reset");
	}

	IEnumerator Reset(){
        UpdateScore();
        transform.position = resetPos;
        rb.AddForce(Vector3.zero);
        yield return new WaitForSeconds(1.0f);
		rb.AddForce(new Vector3(0,0,-100f));

	}
	
	float hitPos(Vector3 ballPos, Vector3 playerPos, float bounds) {
       
        return (ballPos.x - playerPos.x) / bounds;
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player2") {
            float z = hitPos(transform.position, col.transform.position, col.collider.bounds.size.z);

            Vector3 direction = new Vector3(1, 1,z);
            direction.Normalize();
            rb.AddForce(direction*speed);
        }

        if (col.gameObject.tag == "Player1") {
            float z = hitPos(transform.position, col.transform.position, col.collider.bounds.size.z);

            Vector3 direction = new Vector3(1, 1,-z);
            direction.Normalize();
            rb.AddForce(direction*speed);
            
        }

        if (col.gameObject.tag == "Player1Score") {
            player1Score++;
            StartCoroutine("Reset");
        }
        if (col.gameObject.tag == "Player2Score")
        {
            player2Score++;
            StartCoroutine("Reset");

        }
    }

    void UpdateScore() {
        Player1ScoreText.text = player1Score.ToString();
        Player2ScoreText.text = player2Score.ToString();
    }
}
