using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class levelUnlock : MonoBehaviour
{
    public GameObject gray, green;
    public GameObject greenTick;
    public void Start()
    {
        //PlayerPrefs.SetInt("levelsComplete", 0);
        if (int.Parse(gameObject.name) < PlayerPrefs.GetInt("levelsComplete") && gameObject.name != "1")
        {
            green.SetActive(true);
            gray.SetActive(false);
        }
        else if (gameObject.name == "1")
        {
            green.SetActive(true);
            gray.SetActive(false);
        }
        else if (int.Parse(gameObject.name) == PlayerPrefs.GetInt("levelsComplete") + 1)
        {
            green.SetActive(true);
            gray.SetActive(false);
        }
        else if (int.Parse(gameObject.name) == PlayerPrefs.GetInt("levelsComplete"))
        {
            green.SetActive(true);
            gray.SetActive(false);
        }
        else if (int.Parse(gameObject.name) > PlayerPrefs.GetInt("levelsComplete") + 1)
        {
            gray.SetActive(true);
            green.SetActive(false);
        }
        if (int.Parse(gameObject.name) == PlayerPrefs.GetInt("levelsComplete") + 1)
        {
            greenTick.SetActive(false);
        }
        else
        {
            greenTick.SetActive(true);
        }
    }
}
