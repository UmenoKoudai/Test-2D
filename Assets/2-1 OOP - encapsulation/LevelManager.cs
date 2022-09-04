using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// レベルアップテーブルを管理するクラス
/// </summary>
public class LevelManager : MonoBehaviour
{
    /// <summary>レベルアップテーブルが CSV 形式で格納されているテキスト</summary>
    [SerializeField] TextAsset _levelUpTable = default;
    /// <summary>レベルアップテーブルが入っている Dictionary</summary>
    Dictionary<int, PlayerStats> _levelData = new Dictionary<int, PlayerStats>();

    /// <summary>
    /// Start より先に実行する
    /// </summary>
    void Awake()
    {
        BuildLevelUpTable();
    }

    /// <summary>
    /// _levelUpTable で指定されたテキストアセットから CSV データを読み取り、
    /// レベルアップテーブルを作る
    /// </summary>
    void BuildLevelUpTable()
    {
        // C# の標準ライブラリを使って「一行ずつ読む」という処理をする
        System.IO.StringReader sr = new System.IO.StringReader(_levelUpTable.text);
        // 一行目は列名なので飛ばす
        sr.ReadLine();

        while (true)
        {
            // 一行ずつ読みこんで処理する
            string line = sr.ReadLine();

            // line に何も入っていなかったら終わったとみなして処理を終わる
            if (string.IsNullOrEmpty(line))
            {
                break;
            }

            // 行をカンマ区切りで分割してデータに復元する
            string[] values = line.Split(',');
            int level = int.Parse(values[0]);
            PlayerStats stats = new PlayerStats(level, int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[5]));
            _levelData.Add(level, stats);
        }

        Debug.Log("Finished BuildLevelUpTable");
    }

    /// <summary>
    /// レベルを指定して、レベルアップテーブルからデータを取得する
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public PlayerStats GetData(int level)
    {
        if (_levelData.ContainsKey(level))
        {
            return _levelData[level];
        }

        Debug.LogError($"指定されたレベルは存在しません。level: {level}");
        return default;
    }
}

/// <summary>
/// プレイヤーのパラメーターを格納する構造体
/// </summary>
public struct PlayerStats
{
    public int Level;
    public int Maxhp;
    public int Maxmp;
    public int Attack;
    public int Magic;
    public int Dex;

    public PlayerStats(int level, int maxhp, int maxmp, int attack, int magic, int dex)
    {
        this.Level = level;
        this.Maxhp = maxhp;
        this.Maxmp = maxmp;
        this.Attack = attack;
        this.Magic = magic;
        this.Dex = dex;
    }
}