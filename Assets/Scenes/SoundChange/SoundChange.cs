

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChange : MonoBehaviour
{
    [SerializeField] AudioSource _sound1;
    [SerializeField] AudioSource _sound2;
    // Start is called before the first frame update
    void Start()
    {
        _sound1.GetComponent<AudioSource>();
        _sound2.GetComponent<AudioSource>();
        _sound1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //is trigger�������R���C�_�[�ɓ���������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            Debug.Log("��������");
            _sound1.Stop();
            _sound2.Play();
        }
        
    }
    //�R���C�_�[�ǂ������Ԃ������Ƃ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
