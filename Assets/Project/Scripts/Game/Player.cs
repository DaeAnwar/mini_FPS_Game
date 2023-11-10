using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header ("Visuals")]
    public Camera playerCam;
    [Header("GamePlay")]
    public int iniHealth =100;
    private int Health1;
    public int Health { get { return Health1; } }
    public int IniAmmo = 12;
    public bool isHurt; 

    private int Ammo;
    public int ammo { get { return Ammo; } } 
    // Start is called before the first frame update
    void Start()
    {
        Health1 = iniHealth; 
        Ammo = IniAmmo; 

        
    }

    // Update is called once per frame
    void Update()
    { if (Input.GetMouseButtonDown(0))
        {
            if (Ammo > 0) {
                Ammo--; 
            GameObject BulletObject = Pooling.Instance.GetBullet(true);
            BulletObject.transform.position = playerCam.transform.position + playerCam.transform.forward; 
            BulletObject.transform.forward = playerCam.transform.forward;
        }
        }

    }
            void OnTriggerEnter(Collider otherCollider )
    {
        if (otherCollider.GetComponent<AmmoLoot>() != null)
        { // Colletct loot
            AmmoLoot ammoLoot = otherCollider.GetComponent<AmmoLoot>();
            Ammo += ammoLoot.ammo;
            Destroy(ammoLoot.gameObject);
        } // touch enemy 
        if (isHurt == false) {
            GameObject hazard = null; 

         if (otherCollider.GetComponent<Enemy>() != null) { 
            
              
                Enemy enemy = otherCollider.GetComponent<Enemy>();
                hazard = enemy.gameObject;
                Health1 -= enemy.dmg;
                 
        }else if (otherCollider.GetComponent<Bullet>() != null)
            {
                Bullet bullet = otherCollider.GetComponent<Bullet>();
                if (bullet.ShotByPlayer == false)
                {
                    hazard = bullet.gameObject;
                    Health1-= bullet.dmg;
                    bullet.gameObject.SetActive(false);
                }
            }
            if (hazard != null)
                isHurt = true; 
        }
    }
}
