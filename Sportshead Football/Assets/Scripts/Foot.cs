using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    [SerializeField] float kickForce = 55f;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Football") {
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.position * kickForce);
        }
    }
}
