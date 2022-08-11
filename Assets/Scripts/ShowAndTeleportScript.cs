using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndTeleportScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject objectMove;
    [SerializeField] float targetPosition;

    private Vector3 startPosition;
    private void Start()
    {
        startPosition = objectMove.transform.position;
    }

    public bool reverse;

    private void Update()
    {
        if(reverse)
        {
            objectMove.transform.Translate(new Vector3(1, 0) * speed * Time.deltaTime);
            if (objectMove.transform.position.x >= targetPosition)
            {
                objectMove.transform.position = startPosition;
            }
        }
        else
        {
            objectMove.transform.Translate(new Vector3(-1, 0) * speed * Time.deltaTime);
            if (objectMove.transform.position.x <= targetPosition)
            {
                objectMove.transform.position = startPosition;
            }
        }
    }
}
