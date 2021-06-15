using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leap : MonoBehaviour{

    public GameObject playerObject;
    public float delayklick;
    private float lastKlickTime;

    public void LeapKlick() {

        if (Time.time - lastKlickTime < delayklick) {
            playerObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * playerObject.GetComponent<PlaerController>().directionPlayer * playerObject.GetComponent<PlaerController>().leapPawer);
        }
        else {
            lastKlickTime = Time.time;
        }

    }


}
