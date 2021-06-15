using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDrop : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Plant")) {
            GetComponent<Animator>().Play("DistoerRain2");
        }
        if (collision.CompareTag("Player")) {
            GetComponent<Animator>().Play("DistroerRain1");
        }
    }

}
