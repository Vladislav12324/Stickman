using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adsShowBeginLevel : MonoBehaviour
{
    void Start()
    {
        FGL_YaSdk.Ads.YaAds.ShowFullScreenAds();
    }
}
