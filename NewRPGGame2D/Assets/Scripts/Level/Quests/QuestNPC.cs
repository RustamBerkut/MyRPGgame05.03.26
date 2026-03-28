using UnityEngine;

public class QuestNPC : MonoBehaviour
{
    [TextArea]
    [SerializeField]
    private string _questDescription;
    [SerializeField]
    private string _npcName;
    [SerializeField]
    private string _questTitle;
    [SerializeField]
    private string _questNameForSave;

    [SerializeField]
    private int _questExperience;
    [SerializeField]
    private int _questGold;

    private void OnStartQuest()
    {

    }
    private void OnProcessQuest()
    {

    }
    private void OnEndQuest()
    {

    }
}
