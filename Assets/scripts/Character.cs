using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] protected float health;

    protected EventManager eventManager;
    protected abstract void Die();

    private void Awake() {
        eventManager = GetComponent<EventManager>();
    }

    public void TakeDamage(float amount)
    {
        health-=amount;

        if(health <= 0)
        {
            Die();
        }
    }
}
