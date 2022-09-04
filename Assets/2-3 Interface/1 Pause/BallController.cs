using UnityEngine;

/// <summary>
/// ボールを制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour, IPause
{
    Rigidbody2D _rb = default;
    float _angularVelocity;
    Vector2 _velocity;
    /// <summary>衝突時の効果音</summary>
    AudioSource _audio;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
    }

    public void Pause()
    {
        // 速度・回転を保存し、Rigidbody を停止する
        _angularVelocity = _rb.angularVelocity;
        _velocity = _rb.velocity;
        _rb.Sleep();
        _rb.simulated = false;
    }

    public void Resume()
    {
        // Rigidbody の活動を再開し、保存しておいた速度・回転を戻す
        _rb.simulated = true;
        _rb.WakeUp();
        _rb.angularVelocity = _angularVelocity;
        _rb.velocity = _velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _audio.Play();
    }
}
