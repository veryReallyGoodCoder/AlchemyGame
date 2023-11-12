using Articy.Unity;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{

    [SerializeField] private DialogueManager dialogueManager;

    [Header("Choice Button")]
    [SerializeField] private GameObject yesButton;
    [SerializeField] private GameObject noButton;

    [Header("Opening Scene")]
    [SerializeField] private GameObject startButton;

    [Header("Destination Choice")]
    [SerializeField] private GameObject destinationButton;

    [Header("Family Matter")]
    [SerializeField] private GameObject helpFamilyButton;

    private ArticyObject GetArticyObject(GameObject npc)
    {
        var articyRef = npc.GetComponent<ArticyReference>();

        if (articyRef != null)
        {
            return articyRef.reference.GetObject();
        }

        return null;
    }
    public void StartQuest()
    {
        dialogueManager.StartDialogue(GetArticyObject(startButton));
    }

}
