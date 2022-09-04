using UnityEngine;

/// <summary>
/// アニメーションで回転するギミックを制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Animator))]
public class SpinController : MonoBehaviour, IPause
{
    Animator _anim = default;
    /// <summary>元のアニメーション再生速度を保存しておく</summary>
    float _savedAnimSpeed;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void IPause.Pause()
    {
        // アニメーションを止める（再生速度を0にする）
        _savedAnimSpeed = _anim.speed;
        _anim.speed = 0;
    }

    void IPause.Resume()
    {
        // アニメーションを再開する（再生速度を元に戻す）
        _anim.speed = _savedAnimSpeed;
    }
}
