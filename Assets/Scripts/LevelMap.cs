using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMap : MonoBehaviour
{

    public Sprite imageStarsOn;
    public Sprite imageStarsOff;

    // Start is called before the first frame update
    void Start(){

        int lvlStars = PlayerPrefs.GetInt("lvlStars#" + 1);
        GameObject Star1 = GameObject.Find("1_Star1");
        GameObject Star2 = GameObject.Find("1_Star2");
        GameObject Star3 = GameObject.Find("1_Star3");

        Debug.Log(lvlStars);

        switch (lvlStars) {
            case 1:
                Star1.GetComponent<Image>().sprite = imageStarsOn;
                Star2.GetComponent<Image>().sprite = imageStarsOff;
                Star3.GetComponent<Image>().sprite = imageStarsOff;
                break;
            case 2:
                Star1.GetComponent<Image>().sprite = imageStarsOn;
                Star2.GetComponent<Image>().sprite = imageStarsOn;
                Star3.GetComponent<Image>().sprite = imageStarsOff;
                break;
            case 3:
                Star1.GetComponent<Image>().sprite = imageStarsOn;
                Star2.GetComponent<Image>().sprite = imageStarsOn;
                Star3.GetComponent<Image>().sprite = imageStarsOn;
                break;
        }

        
    }
}
