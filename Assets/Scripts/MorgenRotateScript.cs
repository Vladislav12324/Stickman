using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorgenRotateScript : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private bool _reverse = true;

    private void Update()
    {
        if( _reverse )
        {
            transform.Rotate(new Vector3(0, 0, _rotationSpeed) * Time.deltaTime);
            Debug.Log(transform.localRotation);
            if(transform.localRotation.z >= 0.4)
            {
                _reverse = false;
            }
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -_rotationSpeed) * Time.deltaTime);
            if (transform.localRotation.z <= -0.4)
            {
                _reverse = true;
            }
        }
    }
}
