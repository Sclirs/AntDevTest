using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour{

    public Transform spawnCoinOblast;
    public float spawnMinX = 10f;
    public float spawnMaxX = 38f;
    public float spawnY = 10f;
    public GameObject spawnCoin;

    private void Start() {

        SpawnCoinObject();
    }

    public void SpawnCoinObject() {
        Instantiate(spawnCoin, new Vector3(spawnCoinOblast.position.x + Random.Range(spawnMinX, spawnMaxX), spawnY, spawnCoinOblast.position.z), Quaternion.identity);  
    }

}
