using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallBoard : MonoBehaviour
{
    public GameObject[] board;

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
        for(int i = 0; i < board.Length; i++)
        {
            if(board[i].GetComponent<Image>().sprite == null)
            {
                board[i].GetComponent<Button>().enabled = true;
            }
        }
    }

    public void DisableBoard()
    {
        for(int i = 0; i < board.Length; i++)
        {
            board[i].GetComponent<Button>().enabled = false;
        }
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
}
