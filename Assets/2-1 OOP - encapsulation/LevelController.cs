using UnityEngine;

/// <summary>
/// プレイヤーのパラメーターを管理するコンポーネント
/// </summary>
public class LevelController : MonoBehaviour
{
    /// <summary>レベルアップテーブルを読み込むため</summary>
    [SerializeField] LevelManager _levelManager = default;
    /// <summary>プレイヤーのレベル</summary>
    public int _level = 1;
    /// <summary>プレイヤーのパラメーター</summary>
    public PlayerStats _playerStats = default;

    void Start()
    {
        ReloadData();
    }

    /// <summary>
    /// レベルに対してプレイヤーのパラメーターを読み込み直す
    /// </summary>
    public void ReloadData()
    {
        PlayerStats stats = _levelManager.GetData(_level);

        if (stats.Level != 0)
        {
            _playerStats = _levelManager.GetData(_level);
        }
    }

    /// <summary>
    /// レベルアップする
    /// </summary>
    /// <param name="level">レベルアップさせたいレベル数</param>
    public void LevelUp(int level = 1)
    {
        PlayerStats stats = _levelManager.GetData(_level + level);

        if (stats.Level != 0)
        {
            _level += level;
            _playerStats = _levelManager.GetData(_level);
        }
    }
}
