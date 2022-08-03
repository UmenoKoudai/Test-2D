using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MathTest : MonoBehaviour
{
    void Start()
    {
        //valueの絶対値を返す
        //Mathf.Abs(value)
        var Abs = Mathf.Abs(1);
        Debug.Log($"Abs:{Abs}");

        //2つの値を比較し大きいほうを返す
        //Mathf.Max(value1, value2・・・);
        var Max = Mathf.Max(0.1f, 0.5f);
        Debug.Log($"Max:{Max}");

        //2つの値を比較し小さいほうを返す
        //Mathf.Min(value1, value2・・・);
        var Min = Mathf.Min(0.1f, 0.5f);
        Debug.Log($"Min:{Min}");

        //値を最小値～最大値の範囲に制限する
        //valueの値がminより小さければminを返し、valueの値がmaxより大きければmaxを返し、どちらでもなければvalueを返します。
        //Mathf.Clamp(value, min, max);
        var Clamp = Mathf.Clamp(0.1f, 0.5f, 1f);
        Debug.Log($"Clamp:{Clamp}");

        //切り捨て(float型)
        var Ceil = Mathf.Ceil(1.5f);
        Debug.Log($"Ceil:{Ceil}");

        //切り捨て(int型)
        var CeilToInt = Mathf.CeilToInt(1.5f);
        Debug.Log($"Ceil:{CeilToInt}");

        //切り上げ(float型)
        var Floor = Mathf.Floor(1.5f);
        Debug.Log($"Floor:{Floor}");

        //切り上げ(int型)
        var FloorToInt = Mathf.FloorToInt(1.5f);
        Debug.Log($"Floor:{FloorToInt}");

        //度からラジアンに変換
        var Deg2Rad = 60.0f * Mathf.Deg2Rad;
        Debug.Log($"Deg2Rad:{Deg2Rad}");

        //ラジアンから度に変換
        var Rad2Deg = 1.0f * Mathf.Rad2Deg;
        Debug.Log($"Rad2Deg:{Rad2Deg}");

        //正の無限大を表す
        var Infinity = Mathf.Infinity;
        Debug.Log($"Infinity:{Infinity}");

        //負の無限大を表す
        var NegativeInfinity = Mathf.NegativeInfinity;
        Debug.Log($"NegativeInfinity:{NegativeInfinity}");

        //円周率
        var PI = Mathf.PI;
        Debug.Log($"PI:{PI}");

        //三角関数(サイン、コサイン、タンジェント)
        var Sin = Mathf.Sin(1f);
        var Cos = Mathf.Cos(1f);
        var Tan = Mathf.Tan(1f);
        Debug.Log($"Sin:{Sin} Cos:{Cos} Tan:{Tan}");

        //逆三角関数(アークサイン、アークコサイン、アークタンジェント)
        var Asin = Mathf.Asin(1f);
        var Acos = Mathf.Acos(1f);
        var Atan = Mathf.Atan(1f);
        Debug.Log($"Asin:{Asin} Acos:{Acos} Atan:{Atan}");

        //2点間の角度
        var Atan2 = Mathf.Atan2(1f, 1f);
        Debug.Log($"Atan2:{Atan2}");

        //乗数
        //value1のvalue2乗する
        //Mathf.Pow(value1, value2);
        var Pow = Mathf.Pow(2f, 3f);
        Debug.Log($"Pow:{Pow}");


    }
}
