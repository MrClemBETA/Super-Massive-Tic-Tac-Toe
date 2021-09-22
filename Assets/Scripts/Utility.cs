using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Utility
{
    public static string DetermineWinner(string[] board)
    {
        // Look at rows
        for (int i = 0; i < 3; i++)
        {
            string[] row = { board[i * 3], board[i * 3 + 1], board[i * 3 + 2] };
            if (ThreeInARow(row))
            {
                return row[0];
            }
        }

        // Look at columns
        for (int i = 0; i < 3; i++)
        {
            string[] col = { board[i], board[3 + i], board[6 + i] };
            if (ThreeInARow(col))
            {
                return col[0];
            }
        }

        // Diagonals
        string[] diag = { board[0], board[4], board[8] };
        if (ThreeInARow(diag))
        {
            return diag[0];
        }

        string[] otherDiag = { board[2], board[4], board[6] };
        if (ThreeInARow(otherDiag))
        {
            return otherDiag[0];
        }

        return null;
    }
    public static bool ThreeInARow(String[] letters)
    {
        string letter = letters[0];

        if (letter != null)
        {
            if (letter == letters[1] && letter == letters[2])
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
    }

    public static string PrintBoard(string[] board)
    {
        string value = "";
        for(int i = 0; i < board.Length; i++)
        {
            if (board[i] != null)
                value += board[i];
            else
                value += "-";
            if (i % 3 == 2)
                value += "\n";
        }
        return value;
    }
}

