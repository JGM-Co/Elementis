using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueP1S2 : MonoBehaviour
{
    public Text dialogueText, speakerName;
    public int conversationControl;
    public Button dialogueProgression;
    public GameObject dialogue, speakerBox, speaker, dialogueProgressionya;
    public AudioSource buttonClick;
    public Animator mcAnimator;

    private void Start()
    {
        dialogueProgression.enabled = false;
        dialogueText.text = "Stop right there!";
        speakerName.text = "???";
        conversationControl = 0;
        Invoke("changeText", 18f - Time.deltaTime);
        
        
    }
    public void conversationProgression()
    {
        buttonClick.Play();
        dialogueProgression.enabled = false;
        if(conversationControl == 0)
        {
            dialogueText.text = "These guys are trouble.";
            Invoke("Delay", .1f);
        } else if (conversationControl == 1)
        {
            dialogueText.text = "They're trying to steal the water Elementim in this area.";
            Invoke("Delay", .1f);
        } else if (conversationControl == 2)
        {
            dialogueText.text = "Oh, that's right. Your memory.";
            Invoke("Delay", .1f);
        }
        else if (conversationControl == 3)
        {
            dialogueText.text = "Elementim is the energy that resides in all living things";
            Invoke("Delay", .1f);
        }
        else if (conversationControl == 4)
        {
            dialogueText.text = "in our country.";
            Invoke("Delay", .1f);
        }
        else if (conversationControl == 5)
        {
            dialogueText.text = "We use it for a lot of good things.";
            Invoke("Delay", .1f);
        }
        else if (conversationControl == 6)
        {
            dialogueText.text = "But Inimicus utilizes it for evil purposes.";
            Invoke("Delay", .1f);
        }
        else if (conversationControl == 7)
        {
            speakerName.text = "Grunt 1";
            dialogueText.text = "I think they get the gist, Gramps.";
            Invoke("Delay", .1f);
        }
        else if (conversationControl == 8)
        {
            speakerName.text = "Grunt 2";
            dialogueText.text = "Quit yapping and hand over your Elementim cards already!";
            Invoke("Delay", .1f);
        }
        else if (conversationControl == 9)
        {
            speakerName.text = "Graham";
            dialogueText.text = "You can come and get them.";
            Invoke("Delay", .1f);
        }
        else if (conversationControl == 10)
        {
            speakerName.text = "Grunt 3";
            dialogueText.text = "Well that was easy-";
            Invoke("Delay", .1f);
        }
        else if (conversationControl == 11)
        {
            speakerName.text = "Grunt 1";
            dialogueText.text = "Quiet, you fool. It's a trap.";
            Invoke("Delay", .1f);
        }
        else if (conversationControl == 12)
        {
            speakerName.text = "Graham";
            dialogueText.text = "I guess now is a good time to find out if you have ever";
            Invoke("Delay", .1f);
        }
        else if (conversationControl == 13)
        {
            dialogueText.text = "used Elementim cards in the past.";
            Invoke("Delay", .1f);
        }
        else if (conversationControl == 14)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void changeText()
    {
        dialogueText.text = "Ugh...Inimicus grunts.";
        speakerName.text = "Graham";
        dialogueProgression.enabled = true;
        mcAnimator.Play("MC Sideways Idle 1");
    }
    public void Delay()
    {
        conversationControl++;
        dialogueProgression.enabled = true;
    }
    
}
