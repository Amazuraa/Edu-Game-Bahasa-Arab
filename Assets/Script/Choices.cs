using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choices : MonoBehaviour
{
    public string objName;
    public Sprite objImage;
    public Vector3 objPosition;
    public SpriteRenderer image;
    public Animator animator;
    public Snap target;
    public DropOutline outline;

    // Start is called before the first frame update
    void Start()
    {
        // get starting position
        objPosition = transform.position;
    }

    void OnMouseDrag() {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = pos;

        // change outline
        outline.ChangeOutline(objName);
    }

    void OnMouseUp() {
        // Debug.Log("Released!!");
        float snapRange = target.snapRange;
        float dist = Vector2.Distance(target.transform.position, transform.position);

        if (dist <= snapRange) 
        {
            target.checkAnswer(gameObject);
            transform.position = target.transform.position;
        }
        else
        {
            DefaultPosition();
            outline.DefaultOutline();
        }

        // Debug.Log(dist);
    }

    public void ChangeImage() {
        image.sprite = objImage;
    }

    public void DefaultPosition() {
        // Debug.Log( transform.position +" "+ objPosition);
        transform.position = objPosition;
    }
}
