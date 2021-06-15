using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRain : MonoBehaviour{

    public GameObject spawnObject;
    public float delaySpawn;

    private void Start() {
        StartCoroutine(coroutineSpawnObject());
    }

    IEnumerator coroutineSpawnObject() {
        yield return new WaitForSeconds(delaySpawn);

        Instantiate(spawnObject, new Vector3(transform.position.x + Random.Range(-33f,16f), transform.position.y), Quaternion.identity);
        StartCoroutine(coroutineSpawnObject());
    }
}
