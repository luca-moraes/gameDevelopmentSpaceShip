using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilControl : MonoBehaviour
{
  private float speed = 5.0f;
  private Rigidbody2D rb2d;
  public int tipoProjetil;


  void OnCollisionEnter2D(Collision2D coll) {
    if(tipoProjetil == 0){
        if(coll.collider.CompareTag("cigarro") 
        || coll.collider.CompareTag("marreta")
        || coll.collider.CompareTag("alek")
        || coll.collider.CompareTag("zoio1")
        || coll.collider.CompareTag("zoio2")
        || coll.collider.CompareTag("zoio3"))
        {
          Destroy(gameObject);
        }
    }else if(tipoProjetil == 1){
        if(coll.collider.CompareTag("spirou") 
        || coll.collider.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
  }


  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    var vel = rb2d.velocity;

    if(tipoProjetil == 0)
    {
        vel.x = speed;
    }
    else if(tipoProjetil == 1)
    {
        vel.x = -speed;
    }

    rb2d.velocity = vel;
    var pos = transform.position;

    if (pos.x > 10 || pos.x < -10){
        Destroy(gameObject);
    }

    transform.position = pos;
  }
}