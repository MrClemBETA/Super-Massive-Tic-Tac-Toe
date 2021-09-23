using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject mainBoard;
    public Image mainWinnerImage;
    public Sprite X;
    public Sprite O;

    public Sprite CurrentSprite { get; private set; }
    public Player CurrentPlayer { get; private set; }
    public bool GameOver { get; private set; }

    private Player player1;
    private Player player2;
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
        player1 = new Player("X", "Clem");
        player2 = new Player("O", "Computer");
        CurrentPlayer = player1;
        CurrentSprite = player1.LetterSprite;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePlayer(string boardTag)
    {
        CurrentPlayer = CurrentPlayer.Name == player1.Name ? player2 : player1;
        CurrentSprite = CurrentPlayer.LetterSprite;
        DisplayManager.instance.UpdatePlayerTurn(CurrentPlayer.Letter);
        UpdateAvailableBoards(boardTag);
    }

    private void UpdateAvailableBoards(string boardTag)
    {
        if (!GameOver)
        {
            LargeBoard board = LargeBoard.instance;

            // Check if the next board is playable, if so update the currentBoard. Disable all other boards
            for (int i = 0; i < board.boards.Length; i++)
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

    public void SetWinner(string winner)
    {
        mainWinnerImage.sprite = winner == "X" ? X : O;
        mainWinnerImage.color = new Color(0f, 0f, 0f, .5f);
        GameOver = true;

        // Disable boards
        LargeBoard board = LargeBoard.instance;
        for(int i = 0; i < board.boards.Length; i++)
        {
            board.boards[i].GetComponent<SmallBoard>().DisableBoard();
        }
    }
}
