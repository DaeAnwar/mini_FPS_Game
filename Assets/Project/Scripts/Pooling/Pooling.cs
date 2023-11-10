using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
        private static Pooling instance;
    public static Pooling Instance { get { return instance; } }
   
    
    public GameObject BulletPre;
    public int bulletAmm = 20 ;
    private List <GameObject> bullets; 
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        // Preload
        bullets = new List<GameObject>(bulletAmm); 

        for (int i = 0; i < bulletAmm; i++)
        {
            GameObject PreFabInstance = Instantiate(BulletPre);
            PreFabInstance.transform.SetParent(transform);
            PreFabInstance.SetActive(false); 
            bullets.Add(PreFabInstance);
        }
    }
    public GameObject GetBullet(bool shotByPlayer)
    {
     foreach(GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().ShotByPlayer = shotByPlayer;
                return bullet; 
            }
        }

        GameObject PreFabInstance = Instantiate(BulletPre);
        PreFabInstance.transform.SetParent(transform);
        PreFabInstance.GetComponent<Bullet>().ShotByPlayer = shotByPlayer;
        bullets.Add(PreFabInstance);
        return PreFabInstance; 
    }
}
