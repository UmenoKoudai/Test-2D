using UnityEngine;
using System.Collections;

/// <summary>
/// 砲弾 (Shell) を制御するコンポーネント
/// </summary>
public class ShellController : MonoBehaviour
{
    /// <summary>発射する速度</summary>
    [SerializeField] float m_initialSpeed = 5f;
    [SerializeField] GameObject _effect;

    void Start()
    {
        // Rigidbody を取得して発射する
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = this.transform.up * m_initialSpeed;
    }

    void Update()
    {
        // 下に落ちたら自分自身を破棄する
        if (this.transform.position.y < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Star")
        {
            StartCoroutine(Effect());
        }
        // 何かにぶつかったら自分自身を破棄する
        Destroy(this.gameObject);
    }
    IEnumerator Effect()
    {
        Instantiate(_effect, transform.position, transform.rotation);
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }
}
