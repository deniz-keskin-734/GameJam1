using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayersHealthText : MonoBehaviour
{
    PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = playerHealth.playerCurrentHealth.ToString();
    }
}
