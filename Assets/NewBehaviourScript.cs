using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Button _A;
    [SerializeField] Text _B;
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        float _count = 10 - _timer;
        if(_count <= 0f)
        {
            _A.gameObject.SetActive(true);
            _B.gameObject.SetActive(true);
        }
    }
}
