using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Player : MonoBehaviour
{
    [SerializeField] int _jumpForce;
    [SerializeField] LayerMask _wallLayer;
    [SerializeField] int _moveForce;
    [SerializeField]bool _isGround = true;
    bool _jump = false;
    Vector2 _lineWall = new Vector2(-1f, 1f);
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 start = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(start, start + _lineWall, _wallLayer);
        Debug.DrawLine(start, start + _lineWall);
        float x = Input.GetAxisRaw("Horizontal");
        if(x < 0 || x > 0 && _isGround)
        {
            _rb.velocity = new Vector2(x * _moveForce, transform.position.y);
        }
        if(Input.GetButtonDown("Fire1") && hit.collider)
        {
            if(_jump)
            {
                _lineWall = new Vector2(-1f, 1f);
                _rb.velocity = new Vector2(-1f, 1f).normalized * _jumpForce;
                _jump = false;
            }
            else
            {
                _lineWall = new Vector2(1f, 1f);
                _rb.velocity = new Vector2(1f, 1f).normalized * _jumpForce;
                _jump = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            Debug.Log("’n–Ê‚É’…‚¢‚½");
            _isGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            Debug.Log("’n–Ê‚©‚ç—£‚ê‚½");
            _isGround = false;
        }
    }
}
