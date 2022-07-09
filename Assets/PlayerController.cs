using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _intarval;
    [SerializeField] float _defaltSpeed;
    [SerializeField] float _dushSpeed;
    [SerializeField] float _speed;
    [SerializeField] float _jumpPower;
    bool _dubleClick = false;
    float _timer;
    float _x;
    float _y;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _x = Input.GetAxisRaw("Horizontal");
        //_y = Input.GetAxisRaw("Vertical");
        _rb.velocity = new Vector2(_x * _speed, _y * _speed);
        if (Input.GetButtonDown("Horizontal"))
        {
            if(_dubleClick)
            {
                StartCoroutine(Dush());
                _dubleClick = false;
                _timer = 0;
            }
            else
            {
                _dubleClick = true;
                //_rb.velocity = new Vector2(_x * _defaltSpeed, _y * _defaltSpeed);
            }
        }
        if(_dubleClick)
        {
            _timer += Time.deltaTime;
            if(_timer > _intarval)
            {
                _dubleClick = false;
                _timer = 0;
            }
        }
        if(Input.GetButtonDown("Vertical"))
        {
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    IEnumerator Dush()
    {
        Debug.Log("�_�b�V���J�n");
        _speed = _dushSpeed;
        yield return new WaitForSeconds(0.5f);
        _speed = _defaltSpeed;
        Debug.Log("�_�b�V���I��");
    }
}
