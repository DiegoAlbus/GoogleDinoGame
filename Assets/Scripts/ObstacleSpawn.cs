using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] public GameObject[] obstacle;
	private float timeBetweenSpawn;
    [SerializeField]  private float startTimeBetweenSpawn;
	private float decreaser = 0.01f;
	private float minDecreaser = 0.5f;
	private float randomSpawn;
    [SerializeField] private float scoreToSpawnBirds = 1000;

    // Use this for initialization
    void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (GameManager.instance.PlayerActive)
		{
			if (randomSpawn <= 0)
			{

				if (PlayerController.score <= scoreToSpawnBirds) { 
					int random = Random.Range(0, 3);
					Instantiate(obstacle[random], transform.position, Quaternion.identity);
				} else
				{
					int random = Random.Range(0, obstacle.Length);
                    Instantiate(obstacle[random], transform.position, Quaternion.identity);
                }

				timeBetweenSpawn = startTimeBetweenSpawn;
				randomSpawn = Random.Range(timeBetweenSpawn, timeBetweenSpawn + 1f);

				if (startTimeBetweenSpawn > minDecreaser)
				{
					startTimeBetweenSpawn -= decreaser;
				}

			}
			else
			{
				randomSpawn -= Time.deltaTime;
			}
		}

	}
}
