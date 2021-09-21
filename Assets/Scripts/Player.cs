using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite LetterSprite { get; private set; }
    public string Name { get; private set; }
    public string Letter { get; private set; }
    public Player(string letter, string name)
    {
        Name = name;
        Letter = letter;
        LetterSprite = letter == "X" ? GameManager.instance.X : GameManager.instance.O;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
