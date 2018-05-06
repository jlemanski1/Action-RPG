using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quests/BaseQuest")]
public class Quest : ScriptableObject
{
    new public string name = "New Quest";
    public string questgiver;
    [TextArea]
    public string desc = "Description/Directive";

    //Make a QuestManager that handles active quests & opened quests
        //Make UI for multiple quests
    //Quest in JSON form
    //Add some sort of reward
}
