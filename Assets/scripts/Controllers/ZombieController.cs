using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    // Start is called before the first frame update

    public static ZombieController instance;

    private Enemy enemy;

    public delegate void ZombieDeath(Enemy enemy);

    public static event ZombieDeath OnDeath;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void OnEnable() {
        OnDeath+=OnZombieDead;
    }

    private void OnDisable() {
        OnDeath-=OnZombieDead;
    }

    public void OnZombieDead(Enemy enemy)
    {
        Destroy(enemy.gameObject);
        //Deacrease the ennemy number
    }

    public static ZombieController GetInstance()
    {
        return instance;
    }

    public List<GameObject> SpawEnnemies(int amount)
    {
        List<GameObject> list = new List<GameObject>();

        for(int i = 0; i < amount; i++)
        {
            GameObject go = enemy.SpawnEnnemy();
            go.name = "Zombie" + i;
            list.Add(go);
        }

        return list;
    }

    public void RaiseOnZombieDeath(Enemy enemy)
    {
        OnDeath?.Invoke(enemy);
    }   


}
