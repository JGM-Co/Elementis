using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text dialogueText;
    public int conversationControl;
    public Button dialogueProgression;


    private void Start()
    {
        conversationControl = 0;
        dialogueProgression.enabled = false;
        dialogueText.text = "Huh...what is a person doing all the way out here?";
        Invoke("startConversation", 16);
    }

    public void startConversation()
    {
        dialogueProgression.enabled = true;
    }

    public void continueConversation()
    {
        dialogueProgression.enabled = false;
        if(conversationControl == 0)
        {
            dialogueText.text = "Hello? Can you hear me?";
        }
        Invoke("Delay", 0.1f);
    }

    public void Delay ()
    {
        conversationControl++;
        dialogueProgression.enabled = true;
    }
}
