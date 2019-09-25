using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {

    [SerializeField] private float speed = 1;
	[SerializeField] private float start;
	[SerializeField] private float end;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			transform.Translate(Vector2.left * speed * Time.deltaTime);
			if (transform.position.x <= end)
			{
				Vector2 pos = new Vector2(start, transform.position.y);
				transform.position = pos;
			}
	}
}
