using Articy.Alchemyjam;
using Articy.Unity;
using Articy.Unity.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] private GameObject dialogueDisplay;

    [SerializeField] private Transform branchPanel;

    [SerializeField] private Text dialogueText;

    [SerializeField] private GameObject dialogueChoiceButton;

    [SerializeField] private GameObject closeButton;

    private ArticyFlowPlayer flowPlayer;

    
    // Start is called before the first frame update
    void Start()
    {
        flowPlayer = GetComponent<ArticyFlowPlayer>();
        dialogueDisplay.SetActive(false);
        
    }

    public void StartDialogue(IArticyObject articyObj)
    {
        dialogueDisplay.SetActive(true);
        flowPlayer.StartOn = articyObj;
    }

    public void StopDialogue()
    {
        dialogueDisplay.SetActive(false);
        flowPlayer.FinishCurrentPausedObject();

        foreach(Transform child in branchPanel)
        {
            Destroy(child.gameObject);
        }

        flowPlayer.StartOn = null;

    }

    public void OnFlowPlayerPaused(IFlowObject flowObj)
    {
        dialogueText.text = string.Empty;

        string speaker = string.Empty;
        var objectWithSpeakerText = flowObj as IObjectWithSpeaker;

        if(objectWithSpeakerText != null)
        {
            var speakerEntity = objectWithSpeakerText.Speaker as Entity;
            speaker = speakerEntity.DisplayName;
        }

        var objectWithText = flowObj as IObjectWithText;

        if(objectWithText != null)
        {
            var textEntity = objectWithText.Text;

            dialogueText.text = $"{speaker}\n{textEntity}";
        }
    }

    public void OnBranchesUpdated(IList<Branch> branches)
    {
        foreach(Transform child in branchPanel)
        {
            Destroy(child.gameObject);
        }

        bool dialogueIsDone = true;

        foreach(var branch in branches)
        {
            if(branch.Target is DialogueFragment)
            {
                dialogueIsDone = false;
            }
        }

        if(dialogueIsDone == false)
        {
            if(branches.Count == 1)
            {
                GameObject button = Instantiate(dialogueChoiceButton, branchPanel.transform);
                button.GetComponent<DialogueChoices>().AssignCont(flowPlayer, branches[0]);
            }
            else
            {
                foreach(Branch branch in branches)
                {
                    GameObject button = Instantiate(dialogueChoiceButton, branchPanel.transform);
                    button.GetComponent<DialogueChoices>().AssignBranch(flowPlayer, branch);
                }
            }
        }
        else
        {
            GameObject button = Instantiate(closeButton, branchPanel.transform);
            var buttonComponent = button.GetComponent<Button>();
            buttonComponent.onClick.AddListener(StopDialogue);
        }
    }

}
