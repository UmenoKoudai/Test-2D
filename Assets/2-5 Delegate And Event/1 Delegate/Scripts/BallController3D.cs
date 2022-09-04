using UnityEngine;

public class BallController3D : MonoBehaviour
{
    Rigidbody _rb = default;
    Vector3 _angularVelocity;
    Vector3 _velocity;
    PauseManager3D _pauseManager = default;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _pauseManager = GameObject.FindObjectOfType<PauseManager3D>();  // この処理は Start やると遅いので Awake で行う。OnEnable の方が Start より先に呼ばれるため。
    }

    void OnEnable()
    {
        // 呼んで欲しいメソッドを登録する。
        _pauseManager.OnPauseResume += PauseResume;
    }

    void OnDisable()
    {
        // OnDisable ではメソッドの登録を解除すること。さもないとオブジェクトが無効にされたり破棄されたりした後にエラーになってしまう。
        _pauseManager.OnPauseResume -= PauseResume;
    }

    void PauseResume(bool isPause)
    {
        if (isPause)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Pause()
    {
        // 速度・回転を保存し、Rigidbody を停止する
        _angularVelocity = _rb.angularVelocity;
        _velocity = _rb.velocity;
        _rb.Sleep();
    }

    public void Resume()
    {
        // Rigidbody の活動を再開し、保存しておいた速度・回転を戻す
        _rb.WakeUp();
        _rb.angularVelocity = _angularVelocity;
        _rb.velocity = _velocity;
    }
}
