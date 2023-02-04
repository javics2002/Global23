using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    [SerializeField]
    private TextMeshProUGUI dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialoge();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueBox.text = sentence;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueBox.text = "";

        foreach(char letter in sentence)
        {
            dialogueBox.text += letter;
            
            yield return new WaitForSeconds(0.02f); ;
        }
    } 

    public void EndDialoge()
    {
        dialogueBox.text = "";
        StopAllCoroutines();
    }
}
