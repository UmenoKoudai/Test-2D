using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BombManager : MonoBehaviour
{
    GameObject[] _bombs = default;

    void Start()
    {
        _bombs = GameObject.FindGameObjectsWithTag("Bomb");
    }

    public void DisableAllBombs()
    {
        // パターン 1: System.Action に「別に定義した」メソッドを割り当てる
        System.Action<GameObject> action = DisableBomb;
        _bombs.ToList().ForEach(action);

        // パターン 2: ラムダ式を使う
        //_bombs.ToList().ForEach(b => b.SetActive(false));
        // ラムダ式を使った方が SetActive の引数を変えたりできるので都合がよい
    }

    void DisableBomb(GameObject go)
    {
        go.SetActive(false);
    }
}
