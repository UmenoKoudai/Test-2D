using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandamAttack : MonoBehaviour
{
    [SerializeField] GameObject[] _bulletPrefab;
    [SerializeField] Transform _muzzle1;
    [SerializeField] Transform _muzzle2;
    [SerializeField] Transform _muzzle3;
    [SerializeField] Transform _muzzle4;
    [SerializeField] Slider _hpGage;
    int randomN = 0;
    public float _timer;
    public float _intarval = 0.5f;
    int i;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            _hpGage.value -= 1;
        }
        Debug.Log("‰½‚à‚È‚¢");
        switch (randomN)
        {
            case 0:
                if(i < 3)
                {
                    _timer += Time.deltaTime;
                    if (_timer > _intarval)
                    {
                        foreach (var bullet in _bulletPrefab)
                        {
                            Instantiate(bullet, _muzzle1.position, transform.rotation);
                            Debug.Log("”­ŽË");
                        }
                        Debug.Log("‘Ò‹@");
                        _timer = 0;
                        i++;
                    }
                }
                else
                {
                    Debug.Log("ŽŸ");
                    randomN = Random.Range(0,4);
                    i = 0;
                }
                break;
            case 1:
                if (i < 10)
                {
                    _timer += Time.deltaTime;
                    if (_timer > _intarval)
                    {
                        foreach (var bullet in _bulletPrefab)
                        {
                            Instantiate(bullet, _muzzle2.position, transform.rotation);
                        }
                        _timer = 0;
                        i++;
                    }
                }
                else
                {
                    randomN = Random.Range(0, 4);
                    i = 0;
                }
                break;
            case 2:
                if (i < 10)
                {
                    _timer += Time.deltaTime;
                    if (_timer > _intarval)
                    {
                        foreach (var bullet in _bulletPrefab)
                        {
                            Instantiate(bullet, _muzzle3.position, transform.rotation);
                        }
                        _timer = 0;
                        i++;
                    }
                }
                else
                {
                    randomN = Random.Range(0, 4);
                    i = 0;
                }
                break;
            case 3:
                if (i < 10)
                {
                    _timer += Time.deltaTime;
                    if (_timer > _intarval)
                    {
                        foreach (var bullet in _bulletPrefab)
                        {
                            Instantiate(bullet, _muzzle4.position, transform.rotation);
                        }
                        _timer = 0;
                        i++;
                    }
                }
                else
                {
                    randomN = Random.Range(0, 4);
                    i = 0;
                }
                break;
        }
    }
}
