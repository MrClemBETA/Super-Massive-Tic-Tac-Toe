using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject mainBoard;
    public Sprite X;
    public Sprite O;

    public Sprite CurrentSprite { get; private set; }

    private Player player1;
    private Player player2;
    private Player currentPlayer;
    private string currentBoard;

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
        player1 = new Player(X, "X");
        player2 = new Player(O, "O");
        currentPlayer = player1;
        CurrentSprite = player1.Letter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePlayer(string boardTag)
    {
        currentPlayer = currentPlayer.Name == player1.Name ? player2 : player1;
        CurrentSprite = currentPlayer.Letter;
        UpdateAvailableBoards(boardTag);
    }

    private void UpdateAvailableBoards(string boardTag)
    {
        LargeBoard board = mainBoard.GetComponent<LargeBoard>();

        // Check if the next board is playable, if so update the currentBoard. Disable all other boards
        for(int i = 0; i < board.boards.Length; i++)
            if (board.boards[i].tag == boardTag && board.boards[i].GetComponent<SmallBoard>().TilesAvailable())
                currentBoard = boardTag;

        // Enable and Disable boards
        for (int i = 0; i < board.boards.Length; i++)
            if (board.boards[i].tag == currentBoard)
                board.boards[i].GetComponent<SmallBoard>().EnableBoard();
            else
                board.boards[i].GetComponent<SmallBoard>().DisableBoard();
    }
}
