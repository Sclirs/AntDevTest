using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class stickController : MonoBehaviour{

    public float dumping = 1.5f;
    public float speedTracking;
    public float speedHit; 
    public GameObject trackingObject;
    public float heightTracking;
    public float heightHit;
    public bool tracking = true;
    public bool hit = false;

    private void FixedUpdate() {
        if (tracking) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(trackingObject.transform.position.x, heightTracking, transform.position.z), speedTracking);
        }
        if (hit) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, heightHit, transform.position.z), speedHit);
        }
        if (transform.position.x == trackingObject.transform.position.x && transform.position.y == heightTracking && tracking) {
            tracking = false;
            hit = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Plant") || collision.CompareTag("Player")) {
            tracking = true;
            hit = false;
        }
    }

}



