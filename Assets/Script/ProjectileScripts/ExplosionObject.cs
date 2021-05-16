using System;
using System.Collections;
using System.Collections.Generic;
using Script.ControllerScripts;
using UnityEngine;

public class ExplosionObject : MonoBehaviour
{
    private float _lifeTime = StaticController.EXPLOSION_OBJECT_LIFETIME;
    
    void Start()
    {
        GetComponent<Animator>().Play("Boom");
        InvokeRepeating("LifeTimeDecrement",0,1);
    }

    private void Update()
    {
        if (_lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void LifeTimeDecrement()
    {
        _lifeTime--; 
    }

}
