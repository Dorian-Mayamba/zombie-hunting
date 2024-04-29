using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    // Start is called before the first frame update

    public static ZombieController instance;

    private Enemy enemy;
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

    public void OnZombieDead(Enemy enemy)
    {
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


}
