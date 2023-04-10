using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private void Awake()
    {
        int activeMusicPlayers = FindObjectsOfType<AudioScript>().Length;
        if (activeMusicPlayers > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
