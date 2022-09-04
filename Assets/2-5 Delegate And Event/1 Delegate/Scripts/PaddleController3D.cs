using UnityEngine;

public class PaddleController3D : MonoBehaviour
{
    [SerializeField] float _speed = 1.5f;
    Rigidbody _rb = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        _rb.velocity = this.transform.right * _speed * h;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Rigidbody が衝突したら消す
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if (rb)
        {
            Destroy(rb.gameObject);
        }
    }
}
