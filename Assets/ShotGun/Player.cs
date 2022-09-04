using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _shootPoint;
    [SerializeField] int _moveSpeed;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(X, Y);
        if (dir.magnitude != 0)
        {
            transform.up = dir;
        }
        _rb.velocity = new Vector2(X * _moveSpeed, Y * _moveSpeed);
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bullet, _shootPoint.position, transform.rotation);
        }
    }
}
