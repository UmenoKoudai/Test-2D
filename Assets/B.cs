using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B : MonoBehaviour
{
    [SerializeField] GameObject _Operation;
    [SerializeField] GameObject _Title;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            _Operation.gameObject.SetActive(true);
            _Title.gameObject.SetActive(false);
        }
    }
}
