using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _mistSprite;
    [SerializeField] private BoxCollider2D _manCollider;
    [SerializeField] private float _durationTime;

    private bool _isMist;
    private float _currentTime;

    private void Start()
    {
        _currentTime = _durationTime;
    }

    private void Update()
    {
        _currentTime -= Time.deltaTime;

        if(_currentTime <= 0)
        {
            _isMist = !_isMist;
            _currentTime = _durationTime;
        }

        if (_isMist)
        {
            _manCollider.enabled = true;
            _mistSprite.enabled = true;
        }
        else
        {
            _manCollider.enabled = false;
            _mistSprite.enabled = false;
        }
    }
}
