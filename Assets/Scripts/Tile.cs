using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public string Letter { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Letter = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSprite()
    {
        Debug.Log("Button Pressed");
        Letter = GameManager.instance.CurrentPlayer.Letter;
        Image img = GetComponent<Image>();
        GetComponent<Button>().enabled = false;
        img.sprite = GameManager.instance.CurrentSprite;
        img.color = new Color(img.color.r, img.color.g, img.color.b, 1f);
        GetComponentInParent<SmallBoard>().DetermineWinner();
        GameManager.instance.ChangePlayer(gameObject.tag);
    }
}
