using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    [SerializeField] private float speed = 3;
	//public GameObject effect;
	//TODO PARTICLES

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update()
	{
		if (!GameManager.instance.GameOver)
		{
			transform.Translate(Vector2.left * speed * Time.deltaTime);

			if (transform.position.x <= -10)
			{
				Destroy(this.gameObject);
			}
		} else
		{
			Destroy(gameObject);
		}

	}
}
