using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosaoControl : MonoBehaviour
{
    // public AudioClip somExplosao;
	private AudioSource audioSource;

    public void DestroyExplosao(){
        Destroy(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // audioSource.PlayOneShot(somExplosao);
        Invoke("DestroyExplosao", 2.0f);
    }
}
