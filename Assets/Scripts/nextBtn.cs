using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextBtn : MonoBehaviour
{
    public GameObject ad, noAd;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex - 1 == PlayerPrefs.GetInt("levelsComplete"))
        {
            ad.SetActive(true);
            noAd.SetActive(false);
        }
        else
        {
            noAd.SetActive(true);
            ad.SetActive(false);
        }
    }
}
