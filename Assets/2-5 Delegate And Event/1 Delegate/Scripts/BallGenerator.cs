using UnityEngine;

/// <summary>
/// 一定間隔でボールを生成するコンポーネント
/// </summary>
public class BallGenerator : MonoBehaviour
{
    [SerializeField] GameObject _ballPrefab = default;
    [SerializeField] Transform[] _spawnPoints = default;
    [SerializeField] float _interval = 2f;
    float _timer;

    void Start()
    {
        _timer = _interval;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _interval)
        {
            _timer = 0;

            foreach (var p in _spawnPoints)
            {
                Instantiate(_ballPrefab, p.position, Quaternion.identity);
            }
        }
    }
}
