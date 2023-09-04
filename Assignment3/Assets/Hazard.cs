using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    //AudioSource audio;
    SpriteRenderer spriteR;
    CircleCollider2D circle;
    AudioSource audio;
    ParticleSystem particles;


    // Use this for initialization
    void Start ()
    {
        circle = GetComponent<CircleCollider2D>();
        audio = GetComponent<AudioSource>();
        spriteR = GetComponent<SpriteRenderer>();
        particles = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audio.Play();
        particles.Play();
        spriteR.enabled = false;
        circle.enabled = false;
        Destroy(gameObject, audio.clip.length);
    }

}
