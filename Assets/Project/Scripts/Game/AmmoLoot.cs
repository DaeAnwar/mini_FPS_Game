using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoLoot : MonoBehaviour
{
    public GameObject container;
    public float rotationSpeed = 180f;
    // Start is called before the first frame update
    public int ammo = 12; 

    // Update is called once per frame
    void Update()
    {
        container.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        
    }
}
