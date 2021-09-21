using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallBoard : MonoBehaviour
{
    public GameObject[] board;
    public GameObject winnerImage;

    private Color nextPlayed = new Color(0f, 1f, 0f, .5f);
    private Color blank = new Color(0f, 0f, 0f, 0f);
    private string winner = null;

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
        // Look at rows
        for (int i = 0; i < 3; i++) {
            Tile[] row = { board[i*3].GetComponent<Tile>(), board[i*3 + 1].GetComponent<Tile>(), board[i*3 + 2].GetComponent<Tile>() };
            if (ThreeInARow(row))
            {
                SetWinner(row[i*3].Letter);
                return;
            }
        }

        // Look at columns
        for (int i = 0; i < 3; i++)
        {
            Tile[] col = { board[i].GetComponent<Tile>(), board[3 + i].GetComponent<Tile>(), board[6 + i].GetComponent<Tile>() };
            if (ThreeInARow(col))
            {
                SetWinner(col[i * 3].Letter);
                return;
            }
        }

        // Diagonals
        Tile[] diag = { board[0].GetComponent<Tile>(), board[4].GetComponent<Tile>(), board[8].GetComponent<Tile>() };
        if (ThreeInARow(diag))
        {
            SetWinner(diag[0].Letter);
            return;
        }

        Tile[] otherDiag = { board[2].GetComponent<Tile>(), board[4].GetComponent<Tile>(), board[6].GetComponent<Tile>() };
        if (ThreeInARow(otherDiag))
        {
            SetWinner(otherDiag[0].Letter);
            return;
        }
    }

    public bool ThreeInARow(Tile[] tiles)
    {
        string letter = tiles[0].Letter;

        if(letter != null)
        {
            if (letter == tiles[1].Letter && letter == tiles[2].Letter)
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
    }

    private void SetWinner(string winner)
    {
        winnerImage.GetComponent<Image>().color = new Color(0f, 0f, 0f, .5f);
        if (this.winner == null)
        {
            this.winner = winner;
            if (winner == "X")
            {
                winnerImage.GetComponent<Image>().sprite = GameManager.instance.X;
            }
            else if (winner == "O")
            {
                winnerImage.GetComponent<Image>().sprite = GameManager.instance.O;
            }
        }
    }
}
