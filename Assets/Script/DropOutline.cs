using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOutline : MonoBehaviour
{
    public SpriteRenderer image;
    public Sprite defaultOutline;

    public void ChangeOutline(Sprite img) 
    {
        image.sprite = img;
    }

    public void DefaultOutline()
    {
        image.sprite = defaultOutline;
    }
}


