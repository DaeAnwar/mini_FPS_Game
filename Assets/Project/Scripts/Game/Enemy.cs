using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 5;
    public int dmg = 5; 
    void OntriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<Bullet>()!= null)
        {
            Bullet bullet = otherCollider.GetComponent<Bullet>();
             
            Health -= bullet.dmg;
            bullet.gameObject.SetActive(false);
            if (Health<=0)
            {
                Destroy(gameObject); 
            }
            
        }
    }
}
