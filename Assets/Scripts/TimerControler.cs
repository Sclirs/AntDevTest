using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControler : MonoBehaviour
{
    public Image timerImageControler;
    public float timerGame;
    public GameObject MenuisDeath;

    // Start is called before the first frame update
    void Start(){

        StartCoroutine(TimerControlerGame());

    }

    IEnumerator TimerControlerGame() {
        yield return new WaitForSeconds(0.1f);
        if(timerImageControler.fillAmount >= 1) {
            MenuisDeath.SetActive(true);
            Time.timeScale = 0f;
        }
        else{
            timerImageControler.fillAmount += 1/ timerGame * 0.1f;
            StartCoroutine(TimerControlerGame());
        }
    }

}
