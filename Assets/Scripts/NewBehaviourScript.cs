using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;


    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor Interactor){
        Debug.Log("going next loop");
        return true;
    }
}
