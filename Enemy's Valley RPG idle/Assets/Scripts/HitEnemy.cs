using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitEnemy : MonoBehaviour
{
	void OnMouseDown()
	{
		transform.localScale = new Vector3(0.990f, 0.990f, 0.990f);
		gameObject.GetComponent<Image>().color = new Color(235/255.0f, 36 / 255.0f, 36 / 255.0f);

	}

	void OnMouseUp()
	{
		transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f);
		
		//Destroy(gameObject);
	}
}
