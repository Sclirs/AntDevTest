using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CounterCoin : MonoBehaviour{

    public int lvl;
    public Text Score;
    public float counterCoin;
    public int currentCounterCoin;
    public GameObject panelWin;
    public Animator starsAnimator;
    public GameObject coinStorage;
    public GameObject TimerGame;
    private Animator coinStorageAnimator;
    private Image timerImage;


    private void Start() {
        coinStorageAnimator = coinStorage.GetComponent<Animator>();
        timerImage = TimerGame.GetComponent<Image>();
    }

    private void Update() {
        Score.text = currentCounterCoin.ToString() + "/" + counterCoin.ToString(); 
        if(currentCounterCoin >= counterCoin) {
            panelWin.SetActive(true);
            panelWin.GetComponent<Animator>().SetTrigger(name:"Activ");
            int curretlvlStars = PlayerPrefs.GetInt("lvlStars#" + lvl);
            int curretlvlActiv = PlayerPrefs.GetInt("lvlActiv#" + lvl);
            if (timerImage.fillAmount <= 1 && timerImage.fillAmount > 0.842) {
                panelWin.GetComponent<Animator>().SetTrigger(name: "OneStars");
                if(curretlvlStars < 1) {
                    PlayerPrefs.SetInt("lvlStars#" + lvl, 1);
                }
                if( curretlvlActiv == 0) {
                    PlayerPrefs.SetInt("lvlActiv#" + lvl, 1);
                }
            }else if (timerImage.fillAmount <= 0.842 && timerImage.fillAmount > 0.622) {
                panelWin.GetComponent<Animator>().SetTrigger(name: "TwoStars");
                if (curretlvlStars < 1) {
                    PlayerPrefs.SetInt("lvlStars#" + lvl, 2);
                }
                if (curretlvlActiv == 0) {
                    PlayerPrefs.SetInt("lvlActiv#" + lvl, 1);
                }
            }
            else if (timerImage.fillAmount <= 0.622) {
                panelWin.GetComponent<Animator>().SetTrigger(name: "ThreeStars");
                if (curretlvlStars < 1) {
                    PlayerPrefs.SetInt("lvlStars#" + lvl, 3);
                }
                if (curretlvlActiv == 0) {
                    PlayerPrefs.SetInt("lvlActiv#" + lvl, 1);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Coin")) {
            Destroy(collision.gameObject);
            currentCounterCoin++;
            GetComponent<SpawnCoin>().SpawnCoinObject();
        }

        if(currentCounterCoin == 1) {
            coinStorageAnimator.SetTrigger(name: "One");
        }
        if(currentCounterCoin == Math.Round(counterCoin / 5)){
            coinStorageAnimator.SetTrigger(name: "Two");
        }
        if (currentCounterCoin == Math.Round(counterCoin / 5 * 2)) {
            coinStorageAnimator.SetTrigger(name: "Three");
        }
        if (currentCounterCoin == Math.Round(counterCoin / 5 * 3)) {
            coinStorageAnimator.SetTrigger(name: "Fore");
        }
        if (currentCounterCoin == Math.Round(counterCoin / 5 * 4)) {
            coinStorageAnimator.SetTrigger(name: "Five");
        }
    }
}
