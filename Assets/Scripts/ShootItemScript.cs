using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootItemScript : MonoBehaviour
{
    [SerializeField] private GameObject _shootObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _shootObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
