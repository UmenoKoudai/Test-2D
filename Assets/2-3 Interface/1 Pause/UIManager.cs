using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 一時停止を表示する UI を制御するコンポーネント
/// </summary>
public class UIManager : MonoBehaviour, IPause
{
    /// <summary>一時停止の時にメッセージを表示するテキスト</summary>
    [SerializeField] Text _text = default;
    [SerializeField] string _pauseMessage = "PAUSE";
    [SerializeField] Animator _anim = default;

    void IPause.Pause()
    {
        // アニメーションを再生してメッセージを表示する
        _text.text = _pauseMessage;
        _anim?.Play("Blink");
    }

    void IPause.Resume()
    {
        // 表示を消す
        _text.text = "";
        _anim?.Play("Default");
    }
}
