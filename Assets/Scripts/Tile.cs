using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSprite()
    {
        Image img = GetComponent<Image>();
        GetComponent<Button>().enabled = false;
        img.sprite = GameManager.instance.CurrentSprite;
        img.color = new Color(img.color.r, img.color.g, img.color.b, 1f);
        GameManager.instance.ChangePlayer(gameObject.tag);
    }
}
