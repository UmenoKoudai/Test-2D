using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    [SerializeField] int _shootSpeed;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        float RandamX = Random.Range(0, 10);
        float RandamY = Random.Range(-10, 10);
        Vector3 ShootPoint = new Vector3(0f, RandamY, 0f);
        //_rb.velocity = (ShootPoint - transform.position).normalized * _shootSpeed;
        _rb.velocity = ShootPoint * _shootSpeed;
    }
}
