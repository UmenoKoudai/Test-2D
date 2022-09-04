using UnityEngine;

/// <summary>
/// パドルを制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PaddleController : MonoBehaviour
{
    /// <summary>パドルが動く速さ</summary>
    [SerializeField] float _speed = 1f;
    Rigidbody2D _rb = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 入力を受け付けて、パドルを動かす
        float h =Input.GetAxisRaw("Horizontal");
        _rb.velocity = Vector2.right * h * _speed;
    }
}
