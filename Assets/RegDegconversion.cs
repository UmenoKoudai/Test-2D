using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RegDegconversion : MonoBehaviour
{
    float _rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rotation = transform.rotation.z;
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log($"変換前{transform.rotation.z}");
            Debug.Log($"変換後{transform.rotation.z * Mathf.Rad2Deg}");
            //Debug.Log($"ローカルローテーション{transform.localRotation.z}");
        }
        Debug.Log($"変換後{transform.rotation.z * Mathf.Rad2Deg}");
        //if(transform.q)
    }
}
