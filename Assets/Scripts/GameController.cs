using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Sprite PlLoseSp, PlWinSp;
    public SpriteRenderer player;
    public Sprite ManLoseSp, ManWinSp;
    public Sprite Man2LoseSp, Man2WinSp;
    public SpriteRenderer man;
    public SpriteRenderer man2;

    public LineRenderer line_RendererComp;
    public GameObject line;
    public handMover hand_Mover;
    public SpriteRenderer hand;
    public GameObject manObj;
    public GameObject manObj2;
    Vector3 hatWinOffcet;
    Vector3 hatLoseOffcet;
    public Transform hat;
    public Transform hat2;

    public bool winScale;
    public bool loseScale;
    public string pers;
    public string hatType;
    public int numPers = 1;
    public GameObject endGameDisplay;
    public Text endScreenText;
    public List<string> endLosePhrases;
    public List<string> endWinPhrases;
    public GameObject hint;
    public GameObject playerObj;
    public GameObject cop;
    public bool playerScale;
    public GameObject car;
    bool isWin = false;
    bool isLose = false;

    public AudioSource winSound, loseSound;

    public void Start()
    {
        isWin = false;
        isLose = false;
        Time.timeScale = 1;
        if (hat != null || hat2 != null)
        {
            if (pers == "man")
            {
                hatWinOffcet = new Vector3(-0.49f, 0, 0);
                hatLoseOffcet = new Vector3(2.25f, -0.3f, 0);
                if (hatType == "hair")
                {
                    hatLoseOffcet = new Vector3(1.82f, -0.5f, 0);
                }
            }
            if (pers == "woman")
            {
                hatWinOffcet = new Vector3(-0.7f, 0.1f, 0);
                hatLoseOffcet = new Vector3(-2.33f, 0, 0);
                if (hatType == "hat")
                {
                    hatWinOffcet = new Vector3(0.61f, -0.3f, 0);
                    hatLoseOffcet = new Vector3(2.5f, 0, 0);
                }
                else if (hatType == "longHat")
                {
                    hatWinOffcet = new Vector3(0.61f, -0.3f, 0);
                    hatLoseOffcet = new Vector3(2.03f, -0.5f, 0);
                }
                else if (hatType == "hair")
                {
                    hatWinOffcet = new Vector3(0.67f, -0.1f, 0);
                    hatLoseOffcet = new Vector3(2.02f, -0.4f, 0);
                }
            }
        }
    }
    /*
    public void WinSound()
    {
        isWin = false;
        winSound.Play();
    }
    */
    public void Win()
    {
        if (isLose != true && isWin != true)
        {
            StartCoroutine(waitWin());
            isWin = true;
        }
    }
    IEnumerator waitWin()
    {
        winSound.Play();
        yield return new WaitForSeconds(1);
        if (hat != null)
            hat.position = hat.position + hatWinOffcet;
        Destroy(line.GetComponent<Collider2D>());
        Destroy(hand.GetComponent<Collider2D>());
        if (winScale)
            manObj.transform.localScale = new Vector3(manObj.transform.localScale.x * -1, manObj.transform.localScale.y, manObj.transform.localScale.z);
        player.sprite = PlWinSp;
        man.sprite = ManWinSp;
        if (man2 != null)
            man2.sprite = Man2WinSp;
        hand.enabled = false;
        line_RendererComp.enabled = false;
        if (numPers == 2)
        {
            //man2.sprite = ManWinSp;
            if (hat2 != null)
                hat2.position = hat2.position + hatWinOffcet;
            if (winScale)
                manObj2.transform.localScale = new Vector3(manObj2.transform.localScale.x * 1, manObj2.transform.localScale.y, manObj2.transform.localScale.z);
            else
                manObj2.transform.localScale = new Vector3(manObj2.transform.localScale.x * -1, manObj2.transform.localScale.y, manObj2.transform.localScale.z);
        }

        var random = new System.Random();
        var index = random.Next(0, endWinPhrases.Count);
        endScreenText.text = endWinPhrases[index];
        endGameDisplay.SetActive(true);
        hint.SetActive(false);
        if (playerObj != null)
        {
            if (playerScale)
            {
                playerObj.transform.localScale = new Vector3(playerObj.transform.localScale.x * -1, playerObj.transform.localScale.y, playerObj.transform.localScale.z);
            }
        }
        if (PlayerPrefs.GetInt("levelsComplete") < SceneManager.GetActiveScene().buildIndex)
            PlayerPrefs.SetInt("levelsComplete", PlayerPrefs.GetInt("levelsComplete") + 1);
        if (car != null)
            car.SetActive(false);
        Time.timeScale = 0;
    }
    public void Lose()
    {
        if (isLose != true && isWin != true)
        {
            StartCoroutine(waitLose());
            loseSound.Play();
            isLose = true;
            hand_Mover.lose = true;
        }
    }
    IEnumerator waitLose()
    {
        yield return new WaitForSeconds(1);
        if (hat != null)
            hat.position = hat.position + hatLoseOffcet;
        Destroy(line.GetComponent<Collider2D>());
        Destroy(hand.GetComponent<Collider2D>());
        player.sprite = PlLoseSp;
        man.sprite = ManLoseSp;
        if (man2 != null)
            man2.sprite = Man2LoseSp;
        hand.enabled = false;
        line_RendererComp.enabled = false;
        hint.SetActive(false);
        var random = new System.Random();
        var index = random.Next(0, endLosePhrases.Count);
        endScreenText.text = endLosePhrases[index];
        endGameDisplay.SetActive(true);
        if (playerObj != null)
        {
            if (playerScale)
            {
                playerObj.transform.localScale = new Vector3(playerObj.transform.localScale.x * -1, playerObj.transform.localScale.y, playerObj.transform.localScale.z);
            }
        }
        if (cop != null)
            cop.SetActive(true);
        if (car != null)
            car.SetActive(false);
        Time.timeScale = 0;
    }
}
