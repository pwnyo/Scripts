using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().GetNewDialogue(dialogue);
    }
    public void PlayNext()
    {
        FindObjectOfType<DialogueManager>().PlayDialogueBubble();
    }
}
