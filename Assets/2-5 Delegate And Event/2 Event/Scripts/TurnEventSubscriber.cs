using UnityEngine;

/// <summary>
/// TurnManager から通知を受け取りたい場合はこれを継承してコンポーネントを作ること。
/// </summary>
public class TurnEventSubscriber : MonoBehaviour
{
    /// <summary>
    /// GameObject が Active になる時に呼ばれる
    /// </summary>
    void OnEnable()
    {
        TurnManager.OnEndTurn += OnEndTurn;
        TurnManager.OnBeginTurn += OnBeginTurn;
    }

    /// <summary>
    /// GameObject が非 Active になる時に呼ばれる
    /// </summary>
    void OnDisable()
    {
        TurnManager.OnEndTurn -= OnEndTurn;
        TurnManager.OnBeginTurn += OnBeginTurn;
    }

    /// <summary>
    /// プレイヤーのターン終了時の処理を書く
    /// </summary>
    public virtual void OnEndTurn()
    {
        Debug.Log($"OnEndTurn #{TurnManager.TurnCount.ToString()}");
    }

    /// <summary>
    /// プレイヤーのターン開始時の処理を書く
    /// </summary>
    public virtual void OnBeginTurn()
    {
        Debug.Log($"OnBeginTurn #{TurnManager.TurnCount.ToString()}");
    }
}
