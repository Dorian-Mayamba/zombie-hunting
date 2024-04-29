using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update

    protected override void Die()
    {
        eventManager.RaiseOnZombieDead(this);
        
        //Notify Zoombie manager
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnEnnemy()
    {
        return Instantiate(transform.gameObject, transform.parent, false);
    }
}
