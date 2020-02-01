using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterSpeech;
    public Image image;
    public AudioSource sfxSource;

    private bool inDialogue;
    private bool waitingForNextBubble;

    private int currentBubble;
    private Dialogue currentDialogue;
    private string currentText;
    private char[] currentTextinChars;
    private int currentChar;
    private AudioClip currentSfx;

    public float charInterval;
    public float commaInterval;
    public float periodInterval;
    public float bubbleInterval;

    private float currentWait;
    private float timer;

    private PlayerControl pc;
    //private bool 

    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerControl>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }
    public void GetNewDialogue(Dialogue d)
    {
        currentDialogue = d;
        waitingForNextBubble = true;
        PlayDialogueBubble();
    }
    public void PlayDialogueBubble()
    {
        if (currentBubble < currentDialogue.bubbles.Length)
        {
            sfxSource.Stop();
            StopCoroutine(PlayDialogueBubbleManual());
            StartCoroutine(PlayDialogueBubbleManual());
            currentBubble++;
        }
        else
        {
            Debug.Log("Done!");
        }
        //StartNewBubble();
    }
    IEnumerator PlayDialogueBubbleManual()
    {
        WaitForSeconds wait = new WaitForSeconds(charInterval);
        WaitForSeconds comWait = new WaitForSeconds(commaInterval);
        WaitForSeconds perWait = new WaitForSeconds(periodInterval);

        characterSpeech.maxVisibleCharacters = 0;

        if (currentBubble % 2 == 0)
        {
            characterName.text = currentDialogue.player.characterName;
            image.sprite = currentDialogue.player.image;
            currentSfx = currentDialogue.player.sfx;
        }
        else
        {
            characterName.text = currentDialogue.other.characterName;
            image.sprite = currentDialogue.other.image;
            currentSfx = currentDialogue.other.sfx;
        }

        currentText = currentDialogue.bubbles[currentBubble];
        characterSpeech.text = currentDialogue.bubbles[currentBubble];

        sfxSource.clip = currentSfx;

        foreach (char c in currentText.ToCharArray())
        {
            characterSpeech.maxVisibleCharacters++;

            sfxSource.Play();
            yield return new WaitForSeconds(currentSfx.length);
            sfxSource.Stop();

            /*
            if (c.Equals(','))
            {
                yield return comWait;
            }
            else if (c.Equals('.') || c.Equals('!') || c.Equals('?') || c.Equals('-'))
            {
                yield return perWait;
            }
            else
            {
                yield return wait;
            }*/

        }

        
        Debug.Log(currentBubble);
        
    }

    /*
    IEnumerator PlayDialogueBubbleAuto()
    {
        WaitForSeconds wait = new WaitForSeconds(charInterval);
        WaitForSeconds comWait = new WaitForSeconds(commaInterval);
        WaitForSeconds perWait = new WaitForSeconds(periodInterval);

        for (int i = 0; i < currentDialogue.bubbles.Length; i++)
        {
            characterSpeech.maxVisibleCharacters = 0;

            if (i % 2 == 0)
            {
                characterName.text = currentDialogue.player.characterName;
                image.sprite = currentDialogue.player.image;
                currentSfx = currentDialogue.player.sfx;
            }
            else
            {
                characterName.text = currentDialogue.other.characterName;
                image.sprite = currentDialogue.other.image;
                currentSfx = currentDialogue.other.sfx;
            }

            currentText = currentDialogue.bubbles[i];
            characterSpeech.text = currentDialogue.bubbles[i];

            foreach (char c in currentText.ToCharArray())
            {
                characterSpeech.maxVisibleCharacters++;
                sfxSource.PlayOneShot(currentSfx);
                if (c.Equals(',')) {
                    yield return comWait;
                }
                else if (c.Equals('.') || c.Equals('!') || c.Equals('?'))
                {
                    yield return perWait;
                }
                else
                {
                    yield return wait;
                }
            }

            yield return new WaitForSeconds(bubbleInterval);
        }
    }*/
    /*
    void PlayDialogueBubbleManual()
    {
        Debug.Log(currentBubble);
        if (currentBubble < currentDialogue.bubbles.Length)
        {
            waitingFor
        }
        else
        {
            Debug.Log("Finished dialogue");
            return;
        }

        StartNewBubble();
        
        currentBubble++;
    }
    void PlaySingleChar()
    {
        characterSpeech.maxVisibleCharacters++;
        sfxSource.PlayOneShot(currentSfx);
        char c = currentTextinChars[currentChar];

        if (c.Equals(','))
        {
            currentWait = commaInterval;
        }
        else if (c.Equals('.') || c.Equals('!') || c.Equals('?') || c.Equals('-'))
        {
            currentWait = periodInterval;
        }
        else
        {
            currentWait = charInterval;
        }
        currentChar++;
    }

    void StartNewBubble()
    {
        characterSpeech.maxVisibleCharacters = 0;

        if (currentBubble % 2 == 0)
        {
            characterName.text = currentDialogue.player.characterName;
            image.sprite = currentDialogue.player.image;
            currentSfx = currentDialogue.player.sfx;
        }
        else
        {
            characterName.text = currentDialogue.other.characterName;
            image.sprite = currentDialogue.other.image;
            currentSfx = currentDialogue.other.sfx;
        }

        currentText = currentDialogue.bubbles[currentBubble];
        characterSpeech.text = currentDialogue.bubbles[currentBubble];

        currentTextinChars = currentText.ToCharArray();
    }*/
}
