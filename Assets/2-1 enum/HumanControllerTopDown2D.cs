using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーを動かすためのコンポーネント
/// 状態は「正常、毒、麻痺、死」の 4 種類あり、それぞれ以下のような効果がある。
/// 毒: ライフが徐々に減る
/// 麻痺: 移動速度が落ちる
/// 死: 何もできなくなる（動けない）
/// 正常: 普通に移動でき、ライフも減らない
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class HumanControllerTopDown2D : MonoBehaviour
{
    /// <summary>ライフの最大値</summary>
    [SerializeField] float _maxLife = 100;
    /// <summary>移動速度</summary>
    [SerializeField] float _speed = 1f;
    /// <summary>毒の時にどれくらいライフが減るか</summary>
    [SerializeField] float _lifeReduceSpeedOnPoisoned = 1f;
    /// <summary>麻痺の時にどれくらい移動速度が落ちるか</summary>
    [SerializeField] float _speedReductionRatioOnParalyzed = 0.5f;
    /// <summary>ライフをテキスト表示する</summary>
    [SerializeField] Text _lifeText;
    /// <summary>ライフをゲージで表示する</summary>
    [SerializeField] Slider _lifeGauge;
    Rigidbody2D _rb;
    SpriteRenderer _sprite;
    float _life = 0;
    bool _isPoisoned = false;
    bool _isParalyzed = false;
    bool _isDead = false;
    /// <summary>プレイヤーの状態を表す</summary>
    PlayerState _state = PlayerState.Normal;

    void Start()
    {
        _life = _maxLife;
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 入力検出と移動
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(h, v).normalized;

        // 状態判定
        if (_isParalyzed)
        {
            _rb.velocity = dir * _speed * _speedReductionRatioOnParalyzed;
        }
        else if (_isDead)
        {
            // 何もできなくなる
            _rb.velocity = Vector2.zero;
        }
        else
        {
            _rb.velocity = dir * _speed;

            if (_isPoisoned)
            {
                _life -= _lifeReduceSpeedOnPoisoned * Time.deltaTime;
            }
        }

        // 生死判定
        if (_life < 0 && _isDead == false)
        {
            _isDead = true;
            _sprite.color = Color.red;
        }

        // ライフ表示処理（テキスト）
        if (_lifeText)
        {
            _lifeText.text = _life.ToString("000");
        }

        // ライフ表示処理（ゲージ）
        if (_lifeGauge)
        {
            _lifeGauge.value = _life / _maxLife;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Poison")
        {
            _isPoisoned = true;
            _isParalyzed = false;
            _sprite.color = Color.magenta;
        }
        else if (collision.gameObject.tag == "Paralyze")
        {
            _isPoisoned = false;
            _isParalyzed = true;
            _sprite.color = Color.yellow;
        }
        else
        {
            _isPoisoned = false;
            _isParalyzed = false;
            _sprite.color = Color.white;
        }
    }
}

/// <summary>
/// プレイヤーの状態を表す
/// </summary>
enum PlayerState
{
    /// <summary>通常</summary>
    Normal,
    /// <summary>毒 ライフが減る</summary>
    Poisoned,
    /// <summary>麻痺 移動が遅くなる</summary>
    Paralyzed,
    /// <summary>死</summary>
    Dead,
}
