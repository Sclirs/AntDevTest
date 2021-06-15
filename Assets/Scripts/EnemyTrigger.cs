using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour{

    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Plant") || collision.CompareTag("Player")) {
            enemy.GetComponent<stickController>().tracking = true;
            enemy.GetComponent<stickController>().hit = false;
        }
    }

}
