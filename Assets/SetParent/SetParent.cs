using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetParent : MonoBehaviour
{
    /// <summary>フィールドのオブジェクトを格納</summary>
    GameObject _field;
    /// <summary>車のオブジェクトを格納</summary>
    [SerializeField]GameObject _car;
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        _field = GameObject.FindGameObjectWithTag("Road");
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= 2f)
        {
            //Instantiate(_car, transform.position, transform.rotation);
            GameObject Car = Instantiate(_car);
            Car.transform.position = transform.position;
            Car.transform.SetParent(_field.transform);
            _timer = 0;
        }
    }
}
