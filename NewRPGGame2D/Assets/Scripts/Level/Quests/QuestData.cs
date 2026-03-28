using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quests/QuestData")]
public class QuestData : ScriptableObject
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


}
