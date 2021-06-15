using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferScen : MonoBehaviour{

    public void TransferScenManager(int idScen) {
        ScenTransition.SwitchToScene(idScen);
    } 

}
