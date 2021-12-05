using UnityEngine;
using System.Collections;
public class HeroWaveSpawn : MonoBehaviour {

	public int WaveSize;
	public GameObject HeroPrefab;
	public float EnemyInterval;
	public Transform spawnPoint;
	public float startTime;
	public Transform[] WayPoints;
	// public GameObject Hp;
	int enemyCount=0;
	// public GameObject canvas;
	void Start () {
	 //InvokeRepeating("SpawnHero",startTime,EnemyInterval);
	}
	public void SpawnHeroes () {
	 InvokeRepeating("SpawnHero",startTime,EnemyInterval);
	}
	public void SpawnHeroes (int c) {
		WaveSize = c;
		if(Score.inst.score>20)
		{
	 		InvokeRepeating("SpawnHero",startTime,EnemyInterval);
	 		enemyCount = 0;
	 		Score.inst.score -= 20;
	 	}
	}
	void Update()
	{
		if(enemyCount == WaveSize)
		{
			CancelInvoke("SpawnHero");
		}
	}
	void SpawnHero()
	{
		enemyCount++;
		GameObject enemy = GameObject.Instantiate(HeroPrefab,spawnPoint.position,Quaternion.identity) as GameObject;
		enemy.GetComponent<HeroMove>().waypoints = WayPoints;
		// GameObject hp = GameObject.Instantiate(Hp,Vector3.zero,Quaternion.identity) as GameObject;
		// hp.transform.SetParent(canvas.transform);
		// hp.GetComponent<HpBar>().enemy = enemy;
		// enemy.GetComponent<MoveToWayPoints>().hp = hp;
	}
}