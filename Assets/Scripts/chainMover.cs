using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chainMover : MonoBehaviour
{
    public float targetPos1;
    public float targetPos2;
    public string axis;
    [SerializeField]bool direction = true;

    [SerializeField]private float speed = 0.5f;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 10 && gameObject.name != "car")
            speed = 0.5f * SceneManager.GetActiveScene().buildIndex / 15;
        else if (SceneManager.GetActiveScene().buildIndex >= 10 && gameObject.name == "car")
            speed = 0.7f * SceneManager.GetActiveScene().buildIndex / 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "car")
        {
            if (transform.position.x <= targetPos1 - 1.5f)
                transform.position = Vector3.Lerp(transform.position, new Vector3(targetPos1, transform.position.y, transform.position.z), Time.deltaTime * speed);
            else if (transform.position.x > targetPos1 - 1.5f)
                transform.position = new Vector3(targetPos2, transform.position.y, transform.position.z);
        }
        else
        {
            transform.Rotate(0, 0, 0.5f);
            if (axis == "x")
            {
                if (transform.position.x <= targetPos1 - 1.5f && direction == true)
                    transform.position = Vector3.Lerp(transform.position, new Vector3(targetPos1, transform.position.y, transform.position.z), Time.deltaTime * speed);
                else if (transform.position.x > targetPos1 - 1.5f && direction == true)
                    direction = false;
                else if (transform.position.x >= targetPos2 + 1.5f && direction == false)
                    transform.position = Vector3.Lerp(transform.position, new Vector3(targetPos2, transform.position.y, transform.position.z), Time.deltaTime * speed);
                else if (transform.position.x < targetPos2 + 1.5f && direction == false)
                    direction = true;
            }
            else if (axis == "y")
            {
                if (transform.position.y <= targetPos1 - 1.5f && direction == true)
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, targetPos1, transform.position.z), Time.deltaTime * speed);
                else if (transform.position.y > targetPos1 - 1.5f && direction == true)
                    direction = false;
                else if (transform.position.y >= targetPos2 + 1.5f && direction == false)
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, targetPos2, transform.position.z), Time.deltaTime * speed);
                else if (transform.position.y < targetPos2 + 1.5f && direction == false)
                    direction = true;
            }
        }
    }
}
