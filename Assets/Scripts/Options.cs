using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour{

    public void Pause() {
        Time.timeScale = 0f;
    }
    public void Resume() {
        Time.timeScale = 1f;
    }
    public void TransitionScen(int ScensIndex) {
        SceneManager.LoadScene(ScensIndex);
    }
}
