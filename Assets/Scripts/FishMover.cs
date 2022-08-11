using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMover : MonoBehaviour
{
    [SerializeField] private float minXValue;
    [SerializeField] private float maxXValue;
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] public SpriteFlipDirection _flipDirection;

    public bool reverse;
    public bool isX;

    private void Update()
    {
        if(reverse)
        {
            transform.Translate(new Vector2(1, 0) * _speed * Time.deltaTime);

            if(_spriteRenderer != null)
            {
                if (_flipDirection == SpriteFlipDirection.y)
                    _spriteRenderer.flipY = false;
                else
                    _spriteRenderer.flipX = false;
            }
            

            if (transform.position.x >= maxXValue || (transform.position.y >= maxXValue && isX == false))
                reverse = false;
        }
        else
        {
            transform.Translate(new Vector2(-1, 0) * _speed * Time.deltaTime);

            if (_spriteRenderer != null)
            {
                if (_flipDirection == SpriteFlipDirection.y)
                    _spriteRenderer.flipY = true;
                else
                    _spriteRenderer.flipX = true;
            }
                
            if (transform.position.x <= minXValue || (transform.position.y <= minXValue && isX == false))
                reverse = true;
        }
    }

    public enum SpriteFlipDirection
    {
        x,
        y,
    }
}
