using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestMaster : MonoBehaviour
{
    [SerializeField] private GameObject _self;
    //Object.DontDestroyOnLoad();
    // pause UI remider
    [SerializeField] private GameObject _Hint1;
    [SerializeField] private GameObject _Hint2;

    // UI reminder
    [SerializeField] private TMP_Text _HintText;

    // Call to activate quests
    public bool _questActive1;
    public bool _questActive2;

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdatePauseIndicateor1()
    {
        if(_questActive1 == true)
        {
            _HintText.text = "Defeat the beast!";
            _Hint1.SetActive(true);
        }
        else
        {
            _Hint1.SetActive(false);
        }
    }

    void UpdatePauseIndicateor2()
    {
        if (_questActive2 == true)
        {
            _HintText.text = "Clear the area!";
            _Hint2.SetActive(true);
        }
        else
        {
            _Hint2.SetActive(false);
        }
    }
}
