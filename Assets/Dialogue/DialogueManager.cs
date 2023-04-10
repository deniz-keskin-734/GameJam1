using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TMP_Text actorName;
    public TMP_Text messageText;
    public RectTransform backGroundBox;

    public static bool isConvActive;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        DisplayMessage();
    }

    void DisplayMessage()
    {
        isConvActive = true;
        Message msgToDisplay = currentMessages[activeMessage];
        messageText.text = msgToDisplay.message;
        actorName.text = currentActors[msgToDisplay.actorId].actorName;
        actorImage.sprite = currentActors[msgToDisplay.actorId].sprite;
    }

    public void NextMessage()
    {
        if(activeMessage < currentMessages.Length)
        {
            try
            {
                activeMessage++;
            } catch (Exception e)
            {
                Debug.Log("o");
            }
            DisplayMessage();
        }
        else
        {
            isConvActive = false;
            this.gameObject.SetActive(false);
        }
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N) && isConvActive)
        {
            NextMessage();
        }
    }
}
