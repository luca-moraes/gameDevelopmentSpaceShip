using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
  private float lenght, startpos;
  private float movingSpeed = 5f;
  public GameObject cam;
  // public GameObject sideBackground;
  public float parallaxEffect;
  public float sequenceOrder;
  public float distanceCompensation;
  // public float compensationFaction;

  void Start()
  {
    startpos = transform.position.x;
    lenght = GetComponent<SpriteRenderer>().bounds.size.x;
	}

	void Update()
  {
    transform.position += Vector3.left * Time.deltaTime * movingSpeed * parallaxEffect;
    if(transform.position.x < startpos - (lenght*sequenceOrder)){
      // transform.position = new Vector3(startpos + (0.1f*compensationFaction) + (lenght*distanceCompensation), transform.position.y, transform.position.z);
      // transform.position = new Vector3(sideBackground.transform.position.x + sideBackground.GetComponent<Renderer>().bounds.size.x, transform.position.y, transform.position.z);
      transform.position = new Vector3(startpos + (lenght*distanceCompensation), transform.position.y, transform.position.z);
    }
  }
}