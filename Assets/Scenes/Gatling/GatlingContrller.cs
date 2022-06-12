using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingContrller : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform[] _muzzle;
    [SerializeField] float _intarval = 1;
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        int n = Random.Range(0, 3);
        if (_timer >= _intarval && Input.GetButton("mouse0"))
        {
            Debug.Log("‘Å‚Á‚½");
            _timer = 0;
            Instantiate(_bullet, _muzzle[n].position, transform.rotation);
        }
    }
}
