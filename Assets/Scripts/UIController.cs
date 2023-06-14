using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth playerHealth;

    public GameObject healthTextGO;
    public TMP_Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        healthTextGO = transform.GetChild(0).gameObject;
        healthText = healthTextGO.GetComponent<TMP_Text>();  
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HP: " + playerHealth.health;
    }
}
