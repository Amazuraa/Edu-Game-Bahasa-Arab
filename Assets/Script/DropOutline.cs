using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOutline : MonoBehaviour
{
    public SpriteRenderer image;
    public Outline[] targetOutline;

    public void ChangeOutline(string key) 
    {
        foreach (var val in targetOutline)
        {
            if (val.keyName == key)
            {
                image.sprite = val.keyImage;
                break;
            }
        }
    }

    public void DefaultOutline()
    {
        image.sprite = targetOutline[0].keyImage;
    }
}

[System.Serializable]
public class Outline {
    public string keyName;
    public Sprite keyImage;
}

