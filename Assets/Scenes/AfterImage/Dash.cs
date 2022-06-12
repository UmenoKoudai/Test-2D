using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Dash : MonoBehaviour
{
    [SerializeField] float _dashPower = 2f;
    [SerializeField] float _dashInterval = 1f;
    Rigidbody2D _rb;
    ParticleSystem _particles;
    float _timer = 0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _particles = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(Vector2.right * _dashPower, ForceMode2D.Impulse);
            _timer = _dashInterval;
            Debug.Log("Dash start.");
            _particles.Play();
        }

        if (_timer > 0f)
        {
            _timer -= Time.deltaTime;

            if (_timer < 0f)
            {
                Debug.Log("Dash end.");
                _particles.Stop();
            }
        }
    }
}
