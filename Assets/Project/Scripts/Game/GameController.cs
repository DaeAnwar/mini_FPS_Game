using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{
    [Header("Game")]
    public Player player;
    [Header("UI")]
    public Text AmmoText;
    public Text HealthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
       HealthText.text = "Health: " + player.Health; 
        AmmoText.text = "Ammo : " + player.ammo; 
    }
}
