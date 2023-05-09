using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TrackMousePosition : MonoBehaviour
{
    public TextMeshProUGUI mousePositionText;
    void Update()
    {
        Track();
    }
    private void Track()
    {
        if (Input.mousePosition.x > 0 && Input.mousePosition.x < Screen.width)
        {
            if (Input.mousePosition.y > 0 && Input.mousePosition.y < Screen.height)
            {
                transform.position = Input.mousePosition;
            }
        }
        mousePositionText.text = "X: " + transform.position.x + "\nY: " + transform.position.y;
    }
}
