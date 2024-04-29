using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void ZombieDead(Enemy enemy);

    public delegate void PlayerDead(Player player);
    public static event ZombieDead OnZombieDead;

    public static event PlayerDead OnPlayerDead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        OnZombieDead+=ZombieController.GetInstance().OnZombieDead;
        OnPlayerDead+=PlayerController.GetInstance().OnPlayerDead;
    }

    private void OnDisable() {
        OnZombieDead -= ZombieController.GetInstance().OnZombieDead;
        OnPlayerDead -= PlayerController.GetInstance().OnPlayerDead;
    }

    public void RaiseOnPlayerDead(Player player)
    {
        OnPlayerDead?.Invoke(player);
    }

    public void RaiseOnZombieDead(Enemy ennemy)
    {
        OnZombieDead?.Invoke(ennemy);
    }
}
