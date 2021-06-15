using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenTransition : MonoBehaviour{

    private Animator componentAnimator;
    private static ScenTransition instance;
    private AsyncOperation loadScenOperations;
    private static bool playOpeningAnimation = true;

    private void Start() {
        instance = this;
        componentAnimator = GetComponent<Animator>();
        if (playOpeningAnimation) {
            componentAnimator.SetTrigger(name: "SceneStart");
        }
    }

    public static void SwitchToScene(int ScenId) {
        instance.componentAnimator.SetTrigger(name:"SceneEnd");
        instance.loadScenOperations = SceneManager.LoadSceneAsync(ScenId);
        instance.loadScenOperations.allowSceneActivation = false;
    }
    public void OnAnimatorOver() {
        playOpeningAnimation = true;
        instance.loadScenOperations.allowSceneActivation = true;    
    }

}
