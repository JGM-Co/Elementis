using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text dialogueText;
    public int conversationControl;
    public Button dialogueProgression;
    public GameObject uInput;
    public GameObject dialogue;
    public GameObject speakerBox;
    public GameObject speaker;
    public string playerName;
    public Text nameInput;
    public Button option1;
    public Button option2;
    public GameObject option1ya;
    public GameObject option2ya;
    public GameObject dialogueProgressionya;
    public int grahamPoints;
    public Image blackScreen;


    private void Start()
    {
        conversationControl = 0;
        dialogueProgression.enabled = false;
        dialogueText.text = "Huh...what is a person doing all the way out here?";
        uInput.SetActive(false);
        Invoke("startConversation", 16);
        option1.enabled = false;
        option2.enabled = false;
        option1ya.SetActive(false);
        option2ya.SetActive(false);
        grahamPoints = 0;

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
            Invoke("Delay", 0.1f);

        } else if (conversationControl == 1)
        {
            dialogueText.text = "What? You can't remember anything?!";
            Invoke("Delay", 0.1f);
        }
        else if (conversationControl == 2)
        {
            dialogueText.text = "What about your name?";
            Invoke("Delay", 0.1f);
        }
        else if (conversationControl == 3)
        {
            userInput();
            Invoke("Delay", 0.1f);
        }
        else if (conversationControl == 4)
        {
            getPlayerName();
            Invoke("Delay", 0.1f);
        }
        else if (conversationControl == 5)
        {
            dialogueText.text = "Well, " + playerName + ", want to stay at my house?";
            Invoke("Delay", 0.1f);
        }
        else if (conversationControl == 6)
        {
            dialogueText.text = "At least until you get your memory back.";
            option1.enabled = true;
            option2.enabled = true;
            option1ya.SetActive(true);
            option2ya.SetActive(true);
            dialogueProgression.enabled = false;
            dialogueProgressionya.SetActive(false);
        } else if (conversationControl == 7)
        {
            dialogueText.text = "I think it's dangerous out here.";
            Invoke("Delay", 0.1f);
        }
        else if (conversationControl == 8)
        {
            dialogueText.text = "So please, come with me.";
            conversationControl = 10;
        } else if (conversationControl == 9)
        {
            dialogueText.text = "Let's go!";
            conversationControl = 10;
        } else if (conversationControl == 10)
        {
            blackScreen = GetComponent<Image>();
            var transparent = blackScreen.color;
            transparent.a = .5f;
            blackScreen.color = transparent;
        }
    }

    public void Delay ()
    {
        conversationControl++;
        dialogueProgression.enabled = true;
    }

    public void userInput()
    {
        dialogue.SetActive(false);
        speaker.SetActive(false);
        speakerBox.SetActive(false);
        uInput.SetActive(true);
    }

    public void getPlayerName()
    {
        playerName = nameInput.text;
        dialogue.SetActive(true);
        speaker.SetActive(true);
        speakerBox.SetActive(true);
        uInput.SetActive(false);
        dialogueText.text = "You think it's " + playerName + "?";
    }

    public void dialogueOption1 ()
    {
        grahamPoints -= 5;
        dialogueText.text = "Oh...I was just trying to help.";
        option1.enabled = false;
        option1ya.SetActive(false);
        option2.enabled = false;
        option2ya.SetActive(false);
        dialogueProgression.enabled = true;
        dialogueProgressionya.SetActive(true);
        conversationControl++;
    }

    public void dialogueOption2()
    {
        grahamPoints += 5;
        dialogueText.text = "Great!";
        option1.enabled = false;
        option1ya.SetActive(false);
        option2.enabled = false;
        option2ya.SetActive(false);
        dialogueProgression.enabled = true;
        dialogueProgressionya.SetActive(true);
        conversationControl = 9;
    }
}
