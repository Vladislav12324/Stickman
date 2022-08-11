using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject hint;
    public GameObject soundOff_, soundOn_, musicOff_, musicOn_;
    public AudioMixer soundMix;
    public AudioMixer musicMix;
    public AudioSource buttonSound;

    private bool isSettingsActive = false;
    
    void Start()
    {
        //PlayerPrefs.SetInt("levelsComplete", 0);
        if (musicMix != null && soundMix != null)
        {
            if (PlayerPrefs.GetString("music") == "off")
            {
                musicMix.SetFloat("Volume", -80);
            }
            else
            {
                musicMix.SetFloat("Volume", 0);
            }
            if (PlayerPrefs.GetString("sound") == "off")
            {
                soundMix.SetFloat("Volume", -80);
            }
            else
            {
                soundMix.SetFloat("Volume", 0);
            }
        }
    }
    public void settings()
    {
        buttonSound.Play();
        if (isSettingsActive == true)
        {
            musicOff_.SetActive(false);
            musicOn_.SetActive(false);
            soundOff_.SetActive(false);
            soundOn_.SetActive(false);
            isSettingsActive = false;
        }
        else
        {
            if (PlayerPrefs.GetString("music") == "off")
            {
                musicOff_.SetActive(true);
            }
            else
            {
                musicOn_.SetActive(true);
            }
            if (PlayerPrefs.GetString("sound") == "off")
            {
                soundOff_.SetActive(true);
            }
            else
            {
                soundOn_.SetActive(true);
            }
            isSettingsActive = true;
        }
    }
    public void soundOff()
    {
        buttonSound.Play();
        soundOn_.SetActive(true);
        soundOff_.SetActive(false);
        PlayerPrefs.SetString("sound", "on");
        soundMix.SetFloat("Volume", 0);
    }
    public void soundOn()
    {
        buttonSound.Play();
        soundOff_.SetActive(true);
        soundOn_.SetActive(false);
        PlayerPrefs.SetString("sound", "off");
        soundMix.SetFloat("Volume", -80);
    }
    public void musicOff()
    {
        buttonSound.Play();
        musicOn_.SetActive(true);
        musicOff_.SetActive(false);
        PlayerPrefs.SetString("music", "on");
        musicMix.SetFloat("Volume", 0);
    }
    public void musicOn()
    {
        buttonSound.Play();
        musicOff_.SetActive(true);
        musicOn_.SetActive(false);
        PlayerPrefs.SetString("music", "off");
        musicMix.SetFloat("Volume", -80);
    }
    public void nextLevelNoAd()
    {
        buttonSound.Play();
        if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 2)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
    public void nextLevelAd()
    {
        /*
        buttonSound.Play();
        FGL_YaSdk.Ads.YaAds.ShowFullScreenAds();
        if (PlayerPrefs.GetInt("levelsComplete") < SceneManager.GetActiveScene().buildIndex)
            PlayerPrefs.SetInt("levelsComplete", PlayerPrefs.GetInt("levelsComplete") + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        */
        //записыванием в память о пройденном уровне и заспуске следующего уровня
    }
    public void backToAllLevels()
    {
        buttonSound.Play();
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }
    public void backToPlay()
    {
        buttonSound.Play();
        SceneManager.LoadScene(0);
    }
    public void retry()
    {
        buttonSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void play()
    {
        buttonSound.Play();
        if (PlayerPrefs.GetInt("levelsComplete") + 1 != SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(PlayerPrefs.GetInt("levelsComplete") + 1);
        else
            SceneManager.LoadScene(PlayerPrefs.GetInt("levelsComplete"));
    }
    public void AllLevels()
    {
        buttonSound.Play();
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }
    public void Hint()
    {
        /*
        buttonSound.Play();
        FGL_YaSdk.Ads.YaAds.ShowRewardAds(6775443);
        if (//реклама закончилась)
        {
            hint.SetActive(true);
        }
        */
    }

    public void LoadLevel(int index)
    {
        buttonSound.Play();
        SceneManager.LoadScene(index);
    }
}
