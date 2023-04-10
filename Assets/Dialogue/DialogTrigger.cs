using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    [SerializeField] DialogueManager dm;

    public void StartDialogue()
    {
        dm.gameObject.SetActive(true);
        dm.OpenDialogue(messages, actors);
    }
}

[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string actorName;
    public Sprite sprite;
}