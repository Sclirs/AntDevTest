using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMeneger : MonoBehaviour {

    public void Savelvl(int lvl, int lvlActiv, int lvlStars) {
        PlayerPrefs.SetInt("lvlActiv#" + lvl, lvlActiv);
        PlayerPrefs.SetInt("lvlStars#" + lvl, lvlStars);
    }
}
