using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaerController : MonoBehaviour{

    public float speed = 30f;
    public Vector2 moveVector;
    public int directionPlayer = 0;
    private int chekspeed = 0;
    private bool faceRight = true;
    private Rigidbody2D rigidbodyPlayer;
    public Sprite healthOn;
    public Sprite healthOff;
    public Image[] hearts;
    public int hp;
    private Animator PlayerAnimation;
    private bool AnimatinRuning = false;
    public GameObject MenuisDeath;
    
    [Header("Coin")]
    public Transform holdPoint;
    private GameObject coinObject;
    public Transform raycastPosition;
    public RaycastHit2D[] raycastAll;
    private bool coinDamage = true;

    [Header("leap")]
    public float leapPawer;
    public float leapdelayklick;
    public float leapCooldown;
    public Image leapCooldownObject;
    public bool leapchek;
    private float leaplastKlickTime;

    [Header("Rain")]
    public bool rain;
    public float slowRainDrop;
    public float timeslowRainDrop;
    private bool boolslowRainDrop = false;
    private float currentrainspeed;
    
    [Header("Wind")] 
    public bool wind;
    public bool windright;
    public float windspeed;
    private float currentwindspeed;

    public float speedsecond;

    private void Start() {
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        PlayerAnimation = GetComponent<Animator>();
        Time.timeScale = 1f;
    }

    private void Update() {
        if (coinDamage) {
            raycastAll = Physics2D.RaycastAll(raycastPosition.position, Vector2.right * directionPlayer, 3f);
            foreach (var hit in raycastAll) {
                if (hit.transform.CompareTag("Coin") && Mathf.Abs(hit.transform.position.x - raycastPosition.position.x) < 2.1f && coinObject == null) {
                    coinObject = hit.transform.gameObject;
                }
            }
        }
    }

    private void FixedUpdate() {

        if (wind) {
            if (windright) {
                if (faceRight) {
                    currentwindspeed = 1 + windspeed;
                }
                else {
                    currentwindspeed = 1 - windspeed;
                }
                
            }
            else {
                if (faceRight) {
                    currentwindspeed = 1 - windspeed;
                }
                else {
                    currentwindspeed = 1 + windspeed;
                }
            }
        }
        else {
            currentwindspeed = 1;
        }

        if (rain) {
            if (boolslowRainDrop) {
                currentrainspeed = 1 - slowRainDrop;
            }
            else {
                currentrainspeed = 1;
            }
        }
        else {
            currentrainspeed = 1;
        }


        if(chekspeed > 0) {
            Vector2 vector2 = new Vector2(directionPlayer * speed * currentwindspeed * currentrainspeed, rigidbodyPlayer.velocity.y);
            rigidbodyPlayer.velocity = vector2;
            if (AnimatinRuning == false) {
                PlayerAnimation.SetTrigger(name: "Walking");
                AnimatinRuning = true;
            }
        }
        else {
            if (AnimatinRuning == true) {
                PlayerAnimation.SetTrigger(name: "stait");
                AnimatinRuning = false;
            }
        }

        if(directionPlayer > 0 && !faceRight) {
            Flip();
        }
        else if(directionPlayer < 0 && faceRight) {
            Flip();
        }

        for(int i = 0; i < hearts.Length; i++) {
            if(i < hp) {
                hearts[i].sprite = healthOn;
            }
            else {
                hearts[i].sprite = healthOff;
            }
        }

        //death player 
        if(hp <= 0) {
            PlayerAnimation.Play("Animation_Ant_Death");
            MenuisDeath.SetActive(true);
            Time.timeScale = 0f;
        }

        if(coinObject != null) {
            coinObject.transform.position = holdPoint.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("DamageObject")) {
            hp -= collision.GetComponent<DamageObject>().Damage;
            if(coinObject != null) {
                coinDamage = false;
                coinObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(150f, 200f));
                coinObject = null;
                StartCoroutine(CoinDamage());
            }
        }
        if (collision.CompareTag("Rain") && boolslowRainDrop == false) {
            boolslowRainDrop = true;
            StartCoroutine(SlowRainDrop());
        }
    }

    IEnumerator CoinDamage() {
        yield return new WaitForSeconds(3f);
        coinDamage = true;
    }

    public void RuningDirection(int direction) {
        directionPlayer = direction;
        chekspeed = 1;
    }

    public void ChekSpeedOn() {
        chekspeed = 0;
    }

    private void Flip() {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Restarts() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

    IEnumerator SlowRainDrop() {
        yield return new WaitForSeconds(timeslowRainDrop);
        boolslowRainDrop = false;
    }

    public void LeapKlick() {

        if (Time.time - leaplastKlickTime < leapdelayklick && leapchek) {
            rigidbodyPlayer.AddForce(Vector2.right * directionPlayer * leapPawer);
            leapchek = !leapchek;
            leapCooldownObject.fillAmount = 0;
            PlayerAnimation.SetTrigger(name: "jamp");
            StartCoroutine(LeapCooldownCroutine());
        }
        leaplastKlickTime = Time.time;

    }

    IEnumerator LeapCooldownCroutine() {
        yield return new WaitForSeconds(0.1f);
        if (leapCooldownObject.fillAmount >= 1) {
            leapchek = !leapchek;
            leapCooldownObject.GetComponent<Animator>().Play("Cooldown");
        }
        if (!leapchek) {
            leapCooldownObject.fillAmount += 1 / leapCooldown * 0.1f; 
            StartCoroutine(LeapCooldownCroutine());
        }
    } 

}
