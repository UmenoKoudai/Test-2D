using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class NormalVector : MonoBehaviour
{
    Vector3 _playerPosition;
    Vector3 _lineForWallUp = new Vector3(1f, 0.5f, 0f);
    Vector3 _lineForWallDown = new Vector3(1f, -0.5f, 0f);
    [SerializeField]LayerMask _wallLayer;
    [SerializeField] Vector3 _up;
    [SerializeField] Vector3 _down;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        _playerPosition = transform.position;
        //RaycastHit2D upHit = Physics2D.Linecast(_playerPosition, _playerPosition + _lineForWallUp, _wallLayer);
        //Debug.DrawLine(_playerPosition, _playerPosition + _lineForWallUp);
        //RaycastHit2D downHit = Physics2D.Linecast(_playerPosition, _playerPosition + _lineForWallDown, _wallLayer);
        //Debug.DrawLine(_playerPosition, _playerPosition + _lineForWallDown);

        Vector3 up = new Vector3(_up.y * _down.z - _up.z * _down.y, _up.z * _down.x - _up.x * _down.z, _up.x * _down.y - _up.y * _down.x);
        var UP = up.normalized;
        Debug.DrawLine(_playerPosition, _playerPosition+UP);
    }
}
