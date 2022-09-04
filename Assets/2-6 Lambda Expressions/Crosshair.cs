using UnityEngine;
using System.Collections;
using System.Linq;

public class Crosshair : MonoBehaviour
{
    [SerializeField] float _focusSpeed = 100f;

    GameObject[] _bombs = default;
    GameObject _player = default;
    GameObject _target = default;

    void Start()
    {
        _bombs = GameObject.FindGameObjectsWithTag("Bomb");
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // 自機から一番近くにある爆弾を（計算して）入れる
        GameObject closestBomb = default;

        // *** 自機から一番近い爆弾を求める ***

        // パターン 0: 手続き型プログラミングで計算する
        closestBomb = _bombs[0];

        for (int i = 1; i < _bombs.Length; i++)
        {
            float closestDistance = Vector2.Distance(closestBomb.transform.position, _player.transform.position);
            float currentDistance = Vector2.Distance(_bombs[i].transform.position, _player.transform.position);

            if (currentDistance < closestDistance)
            {
                closestBomb = _bombs[i];
            }
        }

        // パターン 1: Linq の OrderBy メソッドを使い、System.Func を使って、「別に定義した」メソッドを渡す
        //System.Func<GameObject, float> func = Distance;
        //closestBomb = _bombs.OrderBy(func).FirstOrDefault();

        // パターン 2: delegate を使ってメソッドをここに定義してしまう（匿名メソッド）
        //closestBomb = _bombs.OrderBy(delegate(GameObject go)
        //{
        //    float distance = Vector2.Distance(_player.transform.position, go.transform.position);
        //    return distance;
        //}).FirstOrDefault();

        // パターン 3: ラムダ式を使ってメソッドをここに定義してしまう（匿名メソッド）
        //closestBomb = _bombs.OrderBy((GameObject x) =>
        //{
        //    float d = Vector2.Distance(_player.transform.position, x.transform.position);
        //    return d;
        //}).FirstOrDefault();

        // パターン 4: 余計な要素（引数の型指定、引数の()、メソッドの return、メソッドの {}）を全て省略する
        // closestBomb = _bombs.OrderBy(x => Vector2.Distance(_player.transform.position, x.transform.position)).FirstOrDefault();

        // 一番近い爆弾に照準を移動させる
        if (_target != closestBomb)
        {
            _target = closestBomb;
            // Focus(_target.transform.position);
            StopAllCoroutines();
            StartCoroutine(FocusRoutine(_target.transform.position));
        }
    }

    /// <summary>
    /// 指定した GameObject と自機との距離を返す
    /// </summary>
    /// <param name="go"></param>
    /// <returns></returns>
    float Distance(GameObject go)
    {
        float distance = Vector2.Distance(_player.transform.position, go.transform.position);
        return distance;
    }

    /// <summary>
    /// オブジェクトを指定した座標に瞬間移動させる
    /// </summary>
    /// <param name="position">移動先座標</param>
    void Focus(Vector2 position)
    {
        this.transform.position = position;
    }

    /// <summary>
    /// オブジェクトを指定した座標に移動させる
    /// </summary>
    /// <param name="position">移動先座標</param>
    /// <returns></returns>
    IEnumerator FocusRoutine(Vector2 position)
    {
        while (Vector2.Distance(position, this.transform.position) > float.Epsilon)
        {
            this.transform.Translate(((Vector3)position - this.transform.position) * _focusSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
