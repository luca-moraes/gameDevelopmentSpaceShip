using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
  private float lenght, startpos;
  private float movingSpeed = 5f;
  public GameObject cam;
  public float parallaxEffect;

  void Start()
  {
    startpos = transform.position.x;
    lenght = GetComponent<SpriteRenderer>().bounds.size.x;
	}

	void Update()
  {
    transform.position += Vector3.left * Time.deltaTime * movingSpeed * parallaxEffect;
    if(transform.position.x < startpos - lenght ){
      transform.position = new Vector3(startpos, transform.position.y, transform.position.z);
    }
  }
}