using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quests/BaseQuest")]
public class Quest : ScriptableObject
{
    new public string name = "New Quest";

    public GameObject questGiver;

    [Header("Quest Conditions")]
    public Transform destionation;      // Location to reach to end quest
    public int count;                   // Number of items to collect to end quest


    [TextArea]
    public string desc = "Description/Directive";

    [TextAreaa]
    public string story = "Description/Narrative";  // The story written in the journal for the quest

    //Make a QuestManager that handles active quests & opened quests
        //Make UI for multiple quests
    //Quest in JSON form
    //Add some sort of reward
}
