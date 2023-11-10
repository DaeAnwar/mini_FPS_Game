using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float life = 0.7f;
    public float lifeTimer;
    public int dmg=5  ;

    public bool shotByPlayer;
    public bool ShotByPlayer { get { return shotByPlayer; } set { shotByPlayer = value; } }
    // Start is called before the first frame update
    void OnEnable()
    {
        lifeTimer = life;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        lifeTimer -= Time.deltaTime; 
    if  (lifeTimer <= 0f)
        {
            gameObject.SetActive(false); 
        }
    }
}
