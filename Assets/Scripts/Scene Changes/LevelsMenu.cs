using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    public Button level2, level3;
    public GameObject[] starEmptyLv1, starFullLv1, starEmptyLv2, starFullLv2, starEmptyLv3, starFullLv3;
    public static int starScoreLv1 = 0, starScoreLv2 = 0, starScoreLv3 = 0;

    void Awake()
    {
        level2.interactable = false;
        level3.interactable = false;
    }
    void Update()
    {
        if (PlayerController.winLv1)
        {
            level2.interactable = true;
        }
        if (PlayerController.winLv2)
        {
            level3.interactable = true;
        }
        DisplayStar();
    }

    void DisplayStar()
    {
        if (PlayerController.winLv1)
        {
            if (starScoreLv1 == 0)
            {
                starEmptyLv1[0].SetActive(true);
                starEmptyLv1[1].SetActive(true);
                starEmptyLv1[2].SetActive(true);

                starFullLv1[0].SetActive(false);
                starFullLv1[1].SetActive(false);
                starFullLv1[2].SetActive(false);
            }
            if (starScoreLv1 == 1)
            {
                starEmptyLv1[0].SetActive(false);
                starEmptyLv1[1].SetActive(true);
                starEmptyLv1[2].SetActive(true);

                starFullLv1[0].SetActive(true);
                starFullLv1[1].SetActive(false);
                starFullLv1[2].SetActive(false);
            }
            if (starScoreLv1 == 2)
            {
                starEmptyLv1[0].SetActive(false);
                starEmptyLv1[1].SetActive(false);
                starEmptyLv1[2].SetActive(true);

                starFullLv1[0].SetActive(true);
                starFullLv1[1].SetActive(true);
                starFullLv1[2].SetActive(false);
            }
            if (starScoreLv1 == 3)
            {
                starEmptyLv1[0].SetActive(false);
                starEmptyLv1[1].SetActive(false);
                starEmptyLv1[2].SetActive(false);

                starFullLv1[0].SetActive(true);
                starFullLv1[1].SetActive(true);
                starFullLv1[2].SetActive(true);
            }
        }
        if (PlayerController.winLv2)
        {
            if (starScoreLv2 == 0)
            {
                starEmptyLv2[0].SetActive(true);
                starEmptyLv2[1].SetActive(true);
                starEmptyLv2[2].SetActive(true);

                starFullLv2[0].SetActive(false);
                starFullLv2[1].SetActive(false);
                starFullLv2[2].SetActive(false);
            }
            if (starScoreLv2 == 1)
            {
                starEmptyLv2[0].SetActive(false);
                starEmptyLv2[1].SetActive(true);
                starEmptyLv2[2].SetActive(true);

                starFullLv2[0].SetActive(true);
                starFullLv2[1].SetActive(false);
                starFullLv2[2].SetActive(false);
            }
            if (starScoreLv2 == 2)
            {
                starEmptyLv2[0].SetActive(false);
                starEmptyLv2[1].SetActive(false);
                starEmptyLv2[2].SetActive(true);

                starFullLv2[0].SetActive(true);
                starFullLv2[1].SetActive(true);
                starFullLv2[2].SetActive(false);
            }
            if (starScoreLv2 == 3)
            {
                starEmptyLv2[0].SetActive(false);
                starEmptyLv2[1].SetActive(false);
                starEmptyLv2[2].SetActive(false);

                starFullLv2[0].SetActive(true);
                starFullLv2[1].SetActive(true);
                starFullLv2[2].SetActive(true);
            }
        }
        if (PlayerController.winLv3)
        {
            if (starScoreLv3 == 0)
            {
                starEmptyLv3[0].SetActive(true);
                starEmptyLv3[1].SetActive(true);
                starEmptyLv3[2].SetActive(true);

                starFullLv3[0].SetActive(false);
                starFullLv3[1].SetActive(false);
                starFullLv3[2].SetActive(false);
            }
            if (starScoreLv3 == 1)
            {
                starEmptyLv3[0].SetActive(false);
                starEmptyLv3[1].SetActive(true);
                starEmptyLv3[2].SetActive(true);

                starFullLv3[0].SetActive(true);
                starFullLv3[1].SetActive(false);
                starFullLv3[2].SetActive(false);
            }
            if (starScoreLv3 == 2)
            {
                starEmptyLv3[0].SetActive(false);
                starEmptyLv3[1].SetActive(false);
                starEmptyLv3[2].SetActive(true);

                starFullLv3[0].SetActive(true);
                starFullLv3[1].SetActive(true);
                starFullLv3[2].SetActive(false);
            }
            if (starScoreLv3 == 3)
            {
                starEmptyLv3[0].SetActive(false);
                starEmptyLv3[1].SetActive(false);
                starEmptyLv3[2].SetActive(false);

                starFullLv3[0].SetActive(true);
                starFullLv3[1].SetActive(true);
                starFullLv3[2].SetActive(true);
            }
        }
    }
}
