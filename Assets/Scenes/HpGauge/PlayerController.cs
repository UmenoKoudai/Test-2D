using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Image _LIfe;
    [SerializeField] int _Hp = 3;
    [SerializeField] Image _background;
    [SerializeField] Image _gameover;
    float _timer = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_Hp <= 0)
        {
            _background.gameObject.SetActive(true);
            _gameover.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(_timer >= 5 && collision.gameObject.tag == "Enemy")
        {
            _Hp -= 1;
            Life(0.333334f);
            _timer = 0;
        }
    }
    void Life(float life)
    {
        _LIfe.GetComponent<Image>().fillAmount -= life;
    }
}
