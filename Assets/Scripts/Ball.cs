using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float originalSpeed = 15f;
    [SerializeField] float speed = 30f;
    [SerializeField] float speedIncrease = 0.2f;
   
    [SerializeField] Scoreboard scoreboard;

    [SerializeField] AudioClip beepSFX;
    [SerializeField] AudioClip boopSFX;
    [SerializeField] AudioClip brrrSFX;

    AudioSource audio;

    Vector2 spawnPoint = new Vector2(0, 4);
    
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
        audio = GetComponent<AudioSource>();
    }

    float hitFactor(Vector2 ballPos, Vector2 paddelPos, float paddelHeight)
    {
        return (ballPos.y - paddelPos.y) / paddelHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
       

        if (col.gameObject.name == "Padel_Left")
        {
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
            speed += speedIncrease;
            audio.PlayOneShot(beepSFX);
        }

        else if (col.gameObject.name == "Padel_Right")
        {

            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
            speed += speedIncrease;
            audio.PlayOneShot(beepSFX);
        }

        else if (col.gameObject.name == "Left_Goal")
        {

            transform.position = spawnPoint;
            speed = originalSpeed;
            rb.velocity = Vector2.right * speed;

            scoreboard.GiveScore(col.gameObject.name);
            audio.PlayOneShot(brrrSFX);
        }

        else if (col.gameObject.name == "Right_Goal")
        {
            transform.position = spawnPoint;
            speed = originalSpeed;
            rb.velocity = Vector2.right * speed;

            scoreboard.GiveScore(col.gameObject.name);
            audio.PlayOneShot(brrrSFX);
        }
        else
        {
            audio.PlayOneShot(boopSFX);
        }

    }
}
