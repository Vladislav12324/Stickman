using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        if(!PlayerPrefs.HasKey("sound"))
        {
            PlayerPrefs.SetString("sound", "on");
        }

        if(!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetString("music", "on");

        }
    }

}
