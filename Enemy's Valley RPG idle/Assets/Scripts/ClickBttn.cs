using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBttn : MonoBehaviour
{

    void OnMouseDown()
    {
        transform.localScale = new Vector3(0.975f, 0.975f, 0.975f);

    }

    void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
