using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static DialogueObject;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.GameObject dialogueBox;
    [SerializeField] private TMP_Text speakerLabel;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private Image rightSpeakerImage;
    [SerializeField] private Image leftSpeakerImage;
    [SerializeField] private DialogueObject test;

    //[SerializeField] private float waitToChangeText = 2f;

    private TypeEffect typeEffect;

    private void Awake()
    {
        typeEffect = GetComponent<TypeEffect>();
    }

    private void Start()
    {
        CloseDialogue();

        FadeScreen.Instance.FadeIn();

        ShowDialogue(test);
    }

    void SetSpeakerLabel(string speakerName) { speakerLabel.text = speakerName; }

    void SetRightSpeakerSprite(Sprite sprite) 
    {
        rightSpeakerImage.sprite = sprite; 
        leftSpeakerImage.enabled = false;
        rightSpeakerImage.enabled = true;
    }

    void SetLeftSpeakerSprite(Sprite sprite)
    {
        leftSpeakerImage.sprite = sprite;
        rightSpeakerImage.enabled = false;
        leftSpeakerImage.enabled = true;
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);

        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        int dialogueIndex = 0;
        foreach (Speaker speaker in dialogueObject.Dialogue)
        {
            SetSpeakerLabel(dialogueObject.GetSpeaker(dialogueIndex));

            SetSpriteOnPosition(dialogueObject, dialogueIndex);

            dialogueIndex++;

            yield return typeEffect.Run(speaker.dialogue, textLabel);
            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return new WaitForSeconds(1f);
        }

        CloseDialogue();
    }

    void SetSpriteOnPosition(DialogueObject dialogueObject, int index)
    {
        switch (dialogueObject.GetSpritePosition(index))
        {
            case SpritePosition.Right:
                SetRightSpeakerSprite(dialogueObject.GetSprite(index));
                return;
            case SpritePosition.Left:
                SetLeftSpeakerSprite(dialogueObject.GetSprite(index));
                return;
        }
    }

    private void CloseDialogue()
    {
        dialogueBox.SetActive(false);
        textLabel.text = "";

        FadeScreen.Instance.FadeOut();
    }
}
