using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float _initialSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = this.transform.up * _initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >=10)
        {
            Destroy(gameObject);
        }
    }
}
