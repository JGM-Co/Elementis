using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text dialogueText, nameInput;
    public int conversationControl, grahamPoints;
    public Button dialogueProgression, option1, option2;
    public GameObject uInput, dialogue, speakerBox, speaker, option1ya, option2ya, dialogueProgressionya, fpUp, fpDown;
    public string playerName;
    public AudioSource buttonClick, pointsUp, pointsDown;
    public Transform mcPos;
    public Animator mcAnimator;


    private void Start()
    {
        //Reset the conversation control and Graham friendship point variables and dialogue text
        conversationControl = 0;
        grahamPoints = 0;
        dialogueText.text = "Huh...what is a person doing all the way out here?";
        //Disable the buttons and hide UI elements
        dialogueProgression.enabled = false;
        uInput.SetActive(false);
        option1.enabled = false;
        option2.enabled = false;
        option1ya.SetActive(false);
        option2ya.SetActive(false);
        fpUp.SetActive(false);
        fpDown.SetActive(false);
        //Set the MC's y position
        mcPos.position = new Vector2(-0.02f, -1.56f);
        //Call the method that shows the dialogue progression button after the initial timeline animations have played
        Invoke("startConversation", 0.1f);
    }

    public void startConversation()
    {
        //Show the dialogue progression button
        dialogueProgression.enabled = true;
    }

    public void continueConversation()
    {
        buttonClick.Play();
        //Once the dialogue progression button is clicked...
        //Disable the button to prevent dialogue lines from being skipped
        dialogueProgression.enabled = false;
        //Conditions without any additional comments progress the dialogue through changing the text and then calling the function that increases the conversation control variable
        //and enables the button
        if(conversationControl == 0)
        {
            dialogueText.text = "Hello? Can you hear me?";
            Invoke("Delay", 0.1f);

        } else if (conversationControl == 1)
        {
            dialogueText.text = "What? You can't remember anything?!";
            mcPos.position = new Vector2(-0.02f, -1.28f);
            mcAnimator.Play("MC Sideways Idle 1");
            Invoke("Delay", 0.1f);
        }
        else if (conversationControl == 2)
        {
            dialogueText.text = "What about your name?";
            Invoke("Delay", 0.1f);
        }
        else if (conversationControl == 3)
        {
            //Call the function that hides the normal dialogue and allows the user to input their name
            userInput();
            Invoke("Delay", 0.1f);
        }
        else if (conversationControl == 4 && nameInput.text.Length > 0)
        {
            //Call the function that takes the inputed name and stores it in a variable
            getPlayerName();
            Invoke("Delay", 0.1f);
        }
        else if (conversationControl == 4 && nameInput.text.Length == 0)
        {
            //If the user clicks the button but they don't have a name put in, don't increase the variable, but give them more chances to press the button
            dialogueProgression.enabled = true;
        }
        else if (conversationControl == 5)
        {
            dialogueText.text = "Well, " + playerName + ", want to stay at my house?";
            Invoke("Delay", 0.1f);
        }
        else if (conversationControl == 6)
        {
            dialogueText.text = "At least until you get your memory back.";
            //Enables the buttons that allow the user to pick their own answer to Graham's question and siables the dialogue progression button
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
            //Skips over a few numbers in order to get to the condition that ends the cutscene
            conversationControl = 10;
            dialogueProgression.enabled = true;
        } else if (conversationControl == 9)
        {
            dialogueText.text = "Let's go!";
            conversationControl = 10;
            dialogueProgression.enabled = true;
        } else if (conversationControl == 10)
        {
            //Ends the cutscene and loads the next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Delay ()
    {
        //Increase the conversation control variable
        conversationControl++;
        //Enables the dialogue progression button
        dialogueProgression.enabled = true;
    }

    public void userInput()
    {
        //Hides the dialogue and speaker name text, as well as the speaker box, and shows the user input field
        dialogue.SetActive(false);
        speaker.SetActive(false);
        speakerBox.SetActive(false);
        uInput.SetActive(true);
    }

    public void getPlayerName()
    {
        //Takes the recently inputted player name and stores it in a variable
        playerName = nameInput.text;
        //Shows the dialogue and speaker name text, as well as the speaker box, and hides the user input field
        dialogue.SetActive(true);
        speaker.SetActive(true);
        speakerBox.SetActive(true);
        uInput.SetActive(false);
        //Changes the dialogue text to a new line that includes the player name
        dialogueText.text = "You think it's " + playerName + "?";
    }

    public void dialogueOption1 ()
    {
        buttonClick.Play();
        pointsDown.Play();
        //If the player picks the first dialogue option...
        //Decrease friendship points with Graham by 5
        grahamPoints -= 5;
        //Show the graphic indicator of the points decreasing
        fpDown.SetActive(true);
        //Change the dialogue text to a new line
        dialogueText.text = "Oh...I was just trying to help.";
        //Increase the conversation control variable
        conversationControl++;
        //Call the method that hides/disables the appropriate objects/buttons
        optionResult();
    }

    public void dialogueOption2()
    {
        buttonClick.Play();
        pointsUp.Play();
        //If the player picks the second dialogue option...
        //Increase friendship points with Graham by 5
        grahamPoints += 5;
        //Show the graphic indicator of the points increasing
        fpUp.SetActive(true);
        //Change the dialogue text to a new line
        dialogueText.text = "Great!";
        //Increase the conversation control variable
        conversationControl = 9;
        //Call the method that hides/disables the appropriate objects/buttons
        optionResult();
    }


    public void FpDisappear()
    {
        //Hides the relationship change graphic indicators
            fpUp.SetActive(false);
            fpDown.SetActive(false);
    }
    public void optionResult ()
    {
        //Hide the two answers and show the dialogue progression button
        option1ya.SetActive(false);
        option2ya.SetActive(false);
        dialogueProgressionya.SetActive(true);
        //Disable the two answers and enable the dialogue progression button
        option1.enabled = false;
        option2.enabled = false;
        dialogueProgression.enabled = true;
        //Call the method that causes the graphic indicator to hide itself after a few seconds
        Invoke("FpDisappear", 3f);
    }
}
