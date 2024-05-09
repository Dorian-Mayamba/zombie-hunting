using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame updat
    protected override void Die()
    {
        ZombieController.GetInstance().RaiseOnZombieDeath(this);

        //Notify Zoombie manager
    }

    public GameObject SpawnEnnemy()
    {

        Transform[] spawnPoints = GameController.GetInstance().spawnPoints;
        Debug.Log(spawnPoints.Length);
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        return Instantiate(transform.gameObject, spawnPoint.position, Quaternion.identity, spawnPoint);
    }
}
