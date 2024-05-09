using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float bulletDamage;
   
   private void OnCollisionEnter(Collision other) {
        Debug.Log("Collision entered "+other.gameObject.tag);
        if(other.gameObject.CompareTag("Ennemy"))
        {
            Debug.Log("Hit enemy" + other.gameObject.name);
            Enemy ennemy = other.gameObject.GetComponent<Enemy>();
            if(ennemy != null)
            {
                Debug.Log("Take this");
                ennemy.TakeDamage(bulletDamage);
            }
        }

        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Player "+ other.gameObject.name);
            
            Player player= other.gameObject.GetComponent<Player>();
            if(player != null)
            {
                Debug.Log("Player is taking damage");
                player.TakeDamage(bulletDamage);
            }
        }
        Destroy(gameObject);
   }
}
