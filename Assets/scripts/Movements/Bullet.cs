using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float bulletDamage;
   
   private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ennemy"))
        {
            Debug.Log("Hit enemy");
            Enemy ennemy = other.gameObject.GetComponent<Enemy>();
            if(ennemy != null)
            {
                Debug.Log("Take this");
                ennemy.TakeDamage(bulletDamage);
            }
        }
        Destroy(gameObject);
   }
}
