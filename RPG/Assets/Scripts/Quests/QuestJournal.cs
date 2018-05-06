using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestJournal : MonoBehaviour
{
    public GameObject journalUI;

    public Text QuestName;
    public Text QuestGiverName;
    public Text QuestDescription;

    public Quest quest;


	void Start ()
	{
        QuestName.text = quest.name;
        QuestGiverName.text = quest.questgiver;
        QuestDescription.text = quest.desc;
	}

    void Update()
    {
        if (Input.GetButtonDown("Journal"))
        {
            journalUI.SetActive(!journalUI.activeSelf);
        }

    }
}
