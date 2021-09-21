using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite Letter { get; private set; }
    public string Name { get; private set; }

    public Player(Sprite s, string name)
    {
        Name = name;
        Letter = s;
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
