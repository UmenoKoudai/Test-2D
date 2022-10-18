using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailSwitch : MonoBehaviour
{
    [SerializeField] TrailRenderer _target;
    [SerializeField] ParticleSystem _targetParticle;


    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //_target.enabled = !_target.enabled;
            
            if (_targetParticle.isPlaying)
            {
                _targetParticle.Stop();
            }
            else
            {
                _targetParticle.Play();
            }
        }
    }
}
