using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerUITest : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] TMP_Text currentPathText;
    [SerializeField] TMP_Text rollText;
    NodePathPlayer nodePP;


    // Start is called before the first frame update
    void Start()
    {
        rollText.text = "Waiting for roll.";
    }

    // Update is called once per frame
    void Update()
    {
        NodePathPlayer nodePP = player.GetComponent<NodePathPlayer>();
        int currentPath = nodePP.currentPath;
        int rolledAmount = nodePP.rollAmount;
        bool rolled = nodePP.rolled;

        if (rolled)
        {
            rollText.text = rolledAmount.ToString();
            if (rolledAmount == 0)
            {
                rollText.text = "Waiting for roll.";
            }
        }

        currentPathText.text = ("Current path is " + currentPath.ToString());
    }
}
