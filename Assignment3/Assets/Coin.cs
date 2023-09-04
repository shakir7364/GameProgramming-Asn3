using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    AudioSource audio;
    SpriteRenderer spriteR;
    CircleCollider2D circle;

    // Use this for initialization
    void Start()
    {
        circle = GetComponent<CircleCollider2D>();
        audio = GetComponent<AudioSource>();
        spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Collect()
    {
        audio.Play();
        spriteR.enabled = false;
        circle.enabled = false;
        Destroy(gameObject, audio.clip.length);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("Collect", 0);
    }
}
