using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ステータスが表示されているウィンドウを管理する
/// </summary>
public class StatusWindowManager : MonoBehaviour
{
    [SerializeField] Text _statusWindow = default;
    [SerializeField] LevelController _player = default;
    int _lastUpdateLevel = 0;

    void Update()
    {
        // レベルが変わったら再描画する
        if (_player._level != _lastUpdateLevel)
        {
            Refresh();
            _lastUpdateLevel = _player._level;
        }
    }

    /// <summary>
    /// ウィンドウを再描画する
    /// </summary>
    public void Refresh()
    {
        // C# の標準ライブラリで文字列を組み立てる
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        PlayerStats s = _player._playerStats;
        builder.AppendLine(s.Level.ToString());
        builder.AppendLine(s.Maxhp.ToString());
        builder.AppendLine(s.Maxmp.ToString());
        builder.AppendLine(s.Attack.ToString());
        builder.AppendLine(s.Magic.ToString());
        builder.AppendLine(s.Dex.ToString());
        print(builder.ToString());  // Console に出力する

        if (_statusWindow)  // ウインドウに出力する
        {
            _statusWindow.text = builder.ToString();
        }
    }
}
