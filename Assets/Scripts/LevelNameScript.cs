using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelNameScript : MonoBehaviour
{
    [SerializeField] private Text textName;

    private void Start()
    {
        var text = SceneManager.GetActiveScene().name;
        text = text.Insert(5, " ");
        textName.text = text;
    }
}
