using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
  private bool shoot = false;
  private bool teto = false;
  private float speed = 2.0f;
  private float boundY = 4.0f;
  private Rigidbody2D rb2d;
  public GameObject projetil;
  public GameObject explosao;
  public int tipoEnemy;
  public int tipoEnemyFuga;


  void OnCollisionEnter2D(Collision2D coll) {
    if(coll.collider.CompareTag("spirou"))
    {
      GameManager gameManager = FindObjectOfType<GameManager>();
      gameManager.addScore(tipoEnemy);
      gameManager.enemyKilled();
      Instantiate(explosao, transform.position, Quaternion.identity);

      if(tipoEnemy == 3){
        gameManager.venceuFase();
      }

      Destroy(gameObject);
    }
  }

  private void destroyEnemy(){
    GameManager gameManager = FindObjectOfType<GameManager>();
    
    gameManager.addScore(tipoEnemyFuga);
    gameManager.enemyKilled();

    if(this.tipoEnemy == 3){  
      gameManager.perdeuFase();
    }

    Destroy(gameObject);
  }


  private void atirar(){
    var psc = transform.position;
    psc.x -= 0.5f;
    Instantiate(projetil, psc, Quaternion.identity);
    shoot = true;
  }

  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();   
	  boundY = 4.0f; 
    Invoke("atirar", 4.5f);
  }

  void Update()
  {
    var vel = rb2d.velocity;

    if(shoot){
      shoot = false;
      Invoke("atirar", 3.5f);
    }

    vel.x = -speed;

    if(teto){
    vel.y = -speed;
    }
    else{
      vel.y = speed;
    }

    rb2d.velocity = vel;
    var pos = transform.position;

    if (pos.y > boundY) {
      teto = true;
    }
    else if (pos.y < -boundY) {
      teto = false;
    }

    transform.position = pos;

    if(pos.x < -12){
      destroyEnemy();
    }
  }
}