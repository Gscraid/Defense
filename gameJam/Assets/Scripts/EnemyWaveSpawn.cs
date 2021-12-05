using UnityEngine;
using System.Collections;
public class EnemyWaveSpawn : MonoBehaviour {

	public int WaveSize;
	public GameObject EnemyPrefab;
	public float EnemyInterval;
	public Transform spawnPoint;
	public float startTime;
	public Transform[] WayPoints;
	// public GameObject Hp;
	int enemyCount=0;
	// public GameObject canvas;
	void Start () {
	 // InvokeRepeating("SpawnEnemy",startTime,EnemyInterval);
		StartCoroutine(SpawnEnemy());
	}
	void Update()
	{
		// if(enemyCount == WaveSize)
		// {
		// 	CancelInvoke("SpawnEnemy");
		// 	enemyCount = 0;
		// }
		// if(enemyCount == 0)
		// {
		// 	InvokeRepeating("SpawnEnemy",100 * Time.deltaTime, EnemyInterval);
		// }
			
	}
	IEnumerator SpawnWave() // void

	{
		yield return new WaitForSeconds(5f);
		StartCoroutine(SpawnEnemy());
	}
	IEnumerator SpawnEnemy() // void
	{
		enemyCount++;
		GameObject enemy = GameObject.Instantiate(EnemyPrefab,spawnPoint.position,Quaternion.identity) as GameObject;
		enemy.GetComponent<EnemyMove>().waypoints = WayPoints;
		yield return new WaitForSeconds(1f);
		if(enemyCount < WaveSize) StartCoroutine(SpawnEnemy());
		else{
			enemyCount = 0;
			StartCoroutine(SpawnWave());

		}
		// GameObject hp = GameObject.Instantiate(Hp,Vector3.zero,Quaternion.identity) as GameObject;
		// hp.transform.SetParent(canvas.transform);
		// hp.GetComponent<HpBar>().enemy = enemy;
		// enemy.GetComponent<MoveToWayPoints>().hp = hp;
	}
}