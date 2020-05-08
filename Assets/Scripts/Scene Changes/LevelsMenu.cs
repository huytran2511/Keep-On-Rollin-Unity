using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    public Button level2, level3;

    //public GameObject starEmpty1, starEmpty2, starEmpty3;
    //public GameObject starFull1, starFull2, starFull3;
    public GameObject[] starEmptyLv1, starFullLv1;

    public static int starScore = 0;


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
        DisplayStar();


    }

    void DisplayStar()
    {
        if (PlayerController.winLv1)
        {
            if (starScore == 0)
            {
                starEmptyLv1[0].SetActive(true);
                starEmptyLv1[1].SetActive(true);
                starEmptyLv1[2].SetActive(true);

                starFullLv1[0].SetActive(false);
                starFullLv1[1].SetActive(false);
                starFullLv1[2].SetActive(false);
            }
            if (starScore == 1)
            {
                starEmptyLv1[0].SetActive(false);
                starEmptyLv1[1].SetActive(true);
                starEmptyLv1[2].SetActive(true);

                starFullLv1[0].SetActive(true);
                starFullLv1[1].SetActive(false);
                starFullLv1[2].SetActive(false);
            }
            if (starScore == 2)
            {
                starEmptyLv1[0].SetActive(false);
                starEmptyLv1[1].SetActive(false);
                starEmptyLv1[2].SetActive(true);

                starFullLv1[0].SetActive(true);
                starFullLv1[1].SetActive(true);
                starFullLv1[2].SetActive(false);
            }
            if (starScore == 3)
            {
                starEmptyLv1[0].SetActive(false);
                starEmptyLv1[1].SetActive(false);
                starEmptyLv1[2].SetActive(false);

                starFullLv1[0].SetActive(true);
                starFullLv1[1].SetActive(true);
                starFullLv1[2].SetActive(true);
            }
        }
    }
}
