using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintHelper : MonoBehaviour
{
    public Transform hand, bag;

    private void Start()
    {
        LineRenderer line = GetComponent<LineRenderer>();
        line.SetPosition(0, hand.position);
        line.SetPosition(line.positionCount - 1, bag.position);
    }
}
