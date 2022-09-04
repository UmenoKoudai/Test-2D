using UnityEngine;

public class PauseUIManager : MonoBehaviour
{
    [SerializeField] Animator _pauseAnimator = default;
    PauseManager3D _pauseManager = default;

    void Awake()
    {
        _pauseManager = GameObject.FindObjectOfType<PauseManager3D>();  // この処理は Start やると遅いので Awake で行う。OnEnable の方が Start より先に呼ばれるため。
    }

    void OnEnable()
    {
        // 呼んで欲しいメソッドを登録する。
        _pauseManager.OnPauseResume += ShowMessage;
    }

    void OnDisable()
    {
        // OnDisable ではメソッドの登録を解除すること。さもないとオブジェクトが無効にされたり破棄されたりした後にエラーになってしまう。
        _pauseManager.OnPauseResume -= ShowMessage;
    }

    void ShowMessage(bool isPause)
    {
        if (isPause)
        {
            _pauseAnimator.Play("Pause");
        }
        else
        {
            _pauseAnimator.Play("Resume");
        }
    }
}
