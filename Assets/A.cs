using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class A : MonoBehaviour
{
    [SerializeField] float _timer;
    [SerializeField] Text _timerimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        float _count = 10 - _timer;
        _timerimit.text = $"{_count.ToString("00")}";
        if (_count <= 0.01f)
        {
            SceneManager.LoadScene("Title");
        }
        if(Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("STAGE1");
        }
    }
}
