using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choices : MonoBehaviour
{
    public string objName;
    public Sprite objImage;
    public Snap target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDrag() {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = pos;
    }

    void OnMouseUp() {
        // Debug.Log("Released!!");
        float snapRange = target.snapRange;
        float dist = Vector2.Distance(target.transform.position, transform.position);

        if (dist <= snapRange) {
            target.checkAnswer(gameObject);
            transform.position = target.transform.position;
        }

        // Debug.Log(dist);
    }
}
