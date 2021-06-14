using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Football : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    [SerializeField] GameObject echo;
    [SerializeField] float xVelocity = 2.5f;
    [SerializeField] float yVelocity = 2.5f;
    [SerializeField] AudioClip kickSound;
    [SerializeField] AudioClip crossbarHitSound;

    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        InstantiateEcho();
    }

    private void InstantiateEcho() {
        if (Math.Abs(rigidBody.velocity.x) >= xVelocity || Math.Abs(rigidBody.velocity.y) >= yVelocity) {
            if (timeBtwSpawns <= 0) {
                var instance = Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instance, .5f);
                timeBtwSpawns = startTimeBtwSpawns;
            } else {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag != "Ground") {
            PlayHitSFX();
        }
        if (col.gameObject.tag == "Crossbar") {
            PlayCrossbarHitSFX();
        }
    }

    private void PlayCrossbarHitSFX() {
        AudioSource.PlayClipAtPoint(crossbarHitSound, Camera.main.transform.position);
    }

    private void PlayHitSFX() {
        AudioSource.PlayClipAtPoint(kickSound, Camera.main.transform.position);
    }
}
