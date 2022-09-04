﻿using UnityEngine;

/// <summary>
/// 一定時間おきに指定したプレハブから GameObject を生成するコンポーネント
/// </summary>
public class Generator : MonoBehaviour
{
    /// <summary>一定時間おきに生成する GameObject の元となるプレハブ</summary>
    [SerializeField] GameObject m_prefab = default;
    /// <summary>生成する間隔（秒）</summary>
    [SerializeField] float m_interval = 1f;
    /// <summary>true の場合、開始時にまず生成する</summary>
    [SerializeField] bool m_generateOnStart = true;
    /// <summary>タイマー計測用変数</summary>
    float m_timer;

    void Start()
    {
        if (m_generateOnStart)
        {
            m_timer = m_interval;
        }
    }

    void Update()
    {
        // Time.deltaTime は「前フレームからの経過時間」を取得する
        // これを積算して「経過時間」を求めるのは Unity での典型的なプログラミングのパターンである
        m_timer += Time.deltaTime;

        // 「経過時間」が「生成する間隔」を超えたら
        if (m_timer > m_interval)
        {
            m_timer = 0;    // タイマーをリセットしている
            Instantiate(m_prefab, this.transform.position, Quaternion.identity);
        }
    }
}
