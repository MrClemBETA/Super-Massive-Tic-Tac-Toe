using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallBoard : MonoBehaviour
{
    public GameObject[] board;
    public GameObject winnerImage;

    public string Winner { get; private set; }

    private Color nextPlayed = new Color(0f, 1f, 0f, .5f);
    private Color blank = new Color(0f, 0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableBoard()
    {
        // Enable boards
        for(int i = 0; i < board.Length; i++)
        {
            if(board[i].GetComponent<Image>().sprite == null)
            {
                board[i].GetComponent<Button>().enabled = true;
            }
        }

        // Change the background color
        GetComponent<Image>().color = nextPlayed;
    }

    public void DisableBoard()
    {
        // Disable board
        for(int i = 0; i < board.Length; i++)
        {
            board[i].GetComponent<Button>().enabled = false;
        }

        // Change the background color
        GetComponent<Image>().color = blank;
    }

    public bool TilesAvailable()
    {
        bool value = false;
        for(int i = 0; i < board.Length; i++)
        {
            if (board[i].GetComponent<Image>().sprite == null)
            {
                value = true;
                break;
            }
        }

        return value;
    }

    public void DetermineWinner()
    {
        string[] letterBoard = new string[9];

        for(int i = 0; i < board.Length; i++)
        {
            letterBoard[i] = board[i].GetComponent<Tile>().Letter;
        }

        string winner = Utility.DetermineWinner(letterBoard);

        if (winner != null)
            SetWinner(winner);
    }

    private void SetWinner(string winner)
    {
        winnerImage.GetComponent<Image>().color = new Color(0f, 0f, 0f, .5f);
        if (Winner == null)
        {
            Winner = winner;
            if (winner == "X")
            {
                winnerImage.GetComponent<Image>().sprite = GameManager.instance.X;
            }
            else if (winner == "O")
            {
                winnerImage.GetComponent<Image>().sprite = GameManager.instance.O;
            }
        }
        LargeBoard.instance.DetermineWinner();
    }
}
