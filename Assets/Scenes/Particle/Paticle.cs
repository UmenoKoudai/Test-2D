using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paticle : MonoBehaviour
{
    [SerializeField] Text _life;
    [SerializeField] GameObject _particle;
    [SerializeField] GameObject _Enemy;
    //ParticleSystem _particle2;
    int _hp = 5;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem pa = GetComponent<ParticleSystem>();
        _life.text = $"HP:{_hp}";
        if (_hp <= 0)
        {
            Debug.Log("Ž€‚ñ‚¾");
            Instantiate(_particle, transform.position, transform.rotation);
            Destroy(_Enemy);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Enemy")
        {
            _hp -= 1;
        }
    }
    /*private void OnDestroy()
    {
        ParticleSystem pa = GetComponent<ParticleSystem>();
        pa.Play();
    }*/
}
