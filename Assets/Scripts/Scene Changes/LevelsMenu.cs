using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    public Button level2, level3;

    void Awake()
    {
        level2.interactable = false;
        level3.interactable = false;
    }
    void Update()
    {
        //if (Player.winLv1)
        //{
        //    level2.interactable = true;
        //}
        //if (Player.winLv2)
        //{
        //    level3.interactable = true;
        //}
    }
}
