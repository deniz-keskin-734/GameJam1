using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    public void OnMouseDown()
    {
        GetComponent<DialogTrigger>().StartDialogue();
    }
}
