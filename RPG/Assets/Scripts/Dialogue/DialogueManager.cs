using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    public GameObject dialogueBox;

    private Queue<string> sentences;

	void Start ()
	{
        dialogueBox.SetActive(true);
        sentences = new Queue<string>();
	}

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();  //Clear any previous sentences

        //Loop through and place each sentence in the queue
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        //No dialogue left, end dialogue
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //There are sentences remaining
        string sentence = sentences.Dequeue();
        StopAllCoroutines();    //Stop TypeSentence if already running
        StartCoroutine(TypeSentence(sentence));
    }

    //"Animate" dialogue letter by letter
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            //Add sentence letter by letter into dialogue text
            dialogueText.text += letter;
            yield return null;  //wait 1 frame
        }
    }

    private void EndDialogue()
    {
        Debug.Log("Conversation Ended");
        animator.SetBool("isOpen", false);
    }
	
	
}
