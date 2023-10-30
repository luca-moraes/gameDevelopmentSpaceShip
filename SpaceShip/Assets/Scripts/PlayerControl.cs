using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
  public KeyCode moveUp = KeyCode.W;
  public KeyCode moveDown = KeyCode.S;
  public KeyCode shoot = KeyCode.Space;
  public float speed = 10.0f;
  public float boundY = 4.0f;
  private Rigidbody2D rb2d;
  public GameObject spirou;

  	void OnCollisionEnter2D(Collision2D coll) {
    	if(coll.collider.CompareTag("alek") 
        || coll.collider.CompareTag("zoio1")
        || coll.collider.CompareTag("zoio2")
        || coll.collider.CompareTag("zoio3")
        || coll.collider.CompareTag("cigarro")
        || coll.collider.CompareTag("marreta"))
		{
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.hit();
    	}
    }

  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();   
	boundY = 4.0f; 
  }

  void Update()
  {
    var vel = rb2d.velocity;

	if(Input.GetKeyDown(shoot)){
		var psc = transform.position;
		psc.x += 0.5f;
		Instantiate(spirou, psc, Quaternion.identity);
	}

    if (Input.GetKey(moveUp)) {
		vel.y = speed;
	}
	else if (Input.GetKey(moveDown)) {
		vel.y = -speed;
	}
	else {
		vel.y = 0;
	}

	rb2d.velocity = vel;
	var pos = transform.position;

	if (pos.y > boundY) {
		pos.y = boundY;
	}
	else if (pos.y < -boundY) {
		pos.y = -boundY;
	}

    transform.position = pos;
  }
}