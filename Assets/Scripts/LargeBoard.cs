using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LargeBoard : MonoBehaviour
{
    public static LargeBoard instance = null;

    public GameObject[] boards;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < boards.Length; i++)
        {
            boards[i].GetComponent<SmallBoard>().EnableBoard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DetermineWinner()
    {
        string[] letterBoard = new string[9];

        for (int i = 0; i < boards.Length; i++)
        {
            letterBoard[i] = boards[i].GetComponent<SmallBoard>().Winner;
        }
        // Debug.Log(letterBoard.Length);
        // Debug.Log(Utility.PrintBoard(letterBoard));
        string winner = Utility.DetermineWinner(letterBoard);
        if (winner != null)
            GameManager.instance.SetWinner(winner);
    }
}
