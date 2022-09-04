using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceShip : MonoBehaviour
{
    [SerializeField] float _movePower = 5f;
    Rigidbody2D _rb = default;
    Vector2 _dir = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _dir = new Vector2(h, v);

        if (_rb.velocity != Vector2.zero)
        {
            this.transform.up = _rb.velocity;
        }
    }

    void FixedUpdate()
    {
        _rb.AddForce(_dir.normalized * _movePower, ForceMode2D.Force);
    }
}
