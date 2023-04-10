using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInteraction : MonoBehaviour
{
    [SerializeField] GameObject security;
    [SerializeField] GameObject hideSquare;
    private void OnMouseDown()
    {
        hideSquare.SetActive(true);
        security.SetActive(true);
    }
}
