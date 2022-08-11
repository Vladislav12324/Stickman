using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnLevelFinger : MonoBehaviour
{
    [SerializeField] float maxValue;
    [SerializeField] float minValue;

    [SerializeField] float speed;
    [SerializeField] float awaitTime;

    bool isAwait = false;
    float currentTime = 0;

    private void Update()
    {
        if(!Input.GetMouseButton(0))
        {
            HandAnimationPlay();

        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void HandAnimationPlay()
    {
        if (!isAwait)
        {
            GetComponent<SpriteRenderer>().enabled = true;

            transform.Translate(new Vector3(0, -1) * speed * Time.deltaTime);
        }
        else
        {
            currentTime -= Time.deltaTime;
        }

        if (currentTime <= 0 && isAwait)
        {
            isAwait = false;
        }

        if (transform.position.y <= minValue)
        {
            isAwait = true;
            transform.position = new Vector3(transform.position.x, maxValue, transform.position.z);
            GetComponent<SpriteRenderer>().enabled = false;
            currentTime = awaitTime;
        }
    }
}
