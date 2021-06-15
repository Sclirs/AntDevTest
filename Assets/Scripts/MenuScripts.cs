using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour {
    private void Start() {
        Time.timeScale = 1f;
    }
    public void StartGame(int idScen){
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        ScenTransition.SwitchToScene(idScen);
    }
    public void ExitGame() {
        Application.Quit();
    }
}
   
