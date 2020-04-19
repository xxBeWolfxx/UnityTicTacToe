using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public int whoTurn = 0; //x = 0 || O = 1
    public int counter = 0;
    public Button[] TicTacToeSpaces; //playeable space for a game
    public string[] Icons;
    public Text XOturn;
    public Text LastWin;
    public GameObject WiningPanel;
    public int[] MarkedSpaces;
    public int WinMark = 0;
    public int Mode =0;




    // Start is called before the first frame update
    void Start()
    {
        
        GameSetup();
        XOturn.text = Icons[whoTurn];
        LastWin.text = " ";
    }

    void GameSetup()
    {
        for(int i = 0; i < TicTacToeSpaces.Length; i++)
        {
            TicTacToeSpaces[i].interactable = true;
            TicTacToeSpaces[i].GetComponentInChildren<Text>().text = " ";

            MarkedSpaces[i] = -100;
        }
        WiningPanel.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void TicTacToeButton(int WhichNumber)
    {
        if (WinMark == 0)
        {
            TicTacToeSpaces[WhichNumber].GetComponentInChildren<Text>().text = Icons[whoTurn];
            TicTacToeSpaces[WhichNumber].interactable = false;

            MarkedSpaces[WhichNumber] = whoTurn + 1;
            counter++;
            if (counter > 4)
                WinnerCheck();
            if(counter > 8)
            {
                ResetButton();
            }


            if (whoTurn == 0)
            {
                whoTurn = 1;

            }
            else
            {
                whoTurn = 0;
            }
            XOturn.text = Icons[whoTurn];
        }
        else
        {
            GameSetup();
            WinMark = 0;
        }
       
        


    }

    void WinnerCheck()
    {
        int s1 = MarkedSpaces[0] + MarkedSpaces[1] + MarkedSpaces[2];
        int s2 = MarkedSpaces[3] + MarkedSpaces[4] + MarkedSpaces[5];
        int s3 = MarkedSpaces[6] + MarkedSpaces[7] + MarkedSpaces[8];
        int s4 = MarkedSpaces[0] + MarkedSpaces[3] + MarkedSpaces[6];
        int s5 = MarkedSpaces[1] + MarkedSpaces[4] + MarkedSpaces[7];
        int s6 = MarkedSpaces[2] + MarkedSpaces[5] + MarkedSpaces[8];
        int s7 = MarkedSpaces[0] + MarkedSpaces[4] + MarkedSpaces[8];
        int s8 = MarkedSpaces[2] + MarkedSpaces[4] + MarkedSpaces[6];
        var solution = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };
        for (int i = 0; i < solution.Length; i++)
        {
            if (solution[i] == 3 * (whoTurn + 1))
            {
                Debug.Log("Player " + Icons[whoTurn] + " won!");
                LastWin.text = Icons[whoTurn];
                WinnerDisplay();
                WinMark = 1;

                for (int j = 0; j < TicTacToeSpaces.Length; j++)
                    TicTacToeSpaces[j].interactable = true;
                    return;
            }
        }
        
    }
    void WinnerDisplay()
    {
        WiningPanel.SetActive(true);
        if (whoTurn == 0)
            WiningPanel.GetComponentInChildren<Text>().text = "X WON!!";
        else
            WiningPanel.GetComponentInChildren<Text>().text = "O WON!!";

        counter = 0;
    }
    public void ResetButton()
    {
        GameSetup();
        WinMark = 0;
        LastWin.text = " ";
        whoTurn = 0;
        XOturn.text = Icons[whoTurn];
        counter = 0;
    }
}
