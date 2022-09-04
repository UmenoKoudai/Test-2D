using UnityEngine;

/// <summary>
/// 一時停止・再開を制御する。
/// </summary>
public class PauseManager3D : MonoBehaviour
{
    /// <summary>true の時は一時停止とする</summary>
    bool _pauseFlg = false;
    /// <summary>一時停止・再開を制御する関数の型（デリゲート）を定義する</summary>
    public delegate void Pause(bool isPause);
    /// <summary>デリゲートを入れておく変数</summary>
    Pause _onPauseResume = default;

    /// <summary>
    /// 一時停止・再開を入れるデリゲートプロパティ
    /// </summary>
    public Pause OnPauseResume
    {
        get { return _onPauseResume; }
        set { _onPauseResume = value; }
    }

    void Update()
    {
        // ESC キーが押されたら一時停止・再開を切り替える
        if (Input.GetButtonDown("Cancel"))
        {
            PauseResume();
        }
    }

    /// <summary>
    /// 一時停止・再開を切り替える
    /// </summary>
    void PauseResume()
    {
        _pauseFlg = !_pauseFlg;
        _onPauseResume(_pauseFlg);  // これで変数に代入した関数を（全て）呼び出せる
    }
}
