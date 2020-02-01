using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public DialogueCharacter player;
    public DialogueCharacter other;
    [TextArea(3, 10)]
    public string[] bubbles;

    public enum SpeakingOrder
    {
        Player,
        Other
    }
    public SpeakingOrder firstSpeaker;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("DialogueCharacterPlayer").GetComponent<DialogueCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
