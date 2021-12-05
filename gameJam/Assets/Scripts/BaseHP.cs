using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHP : MonoBehaviour
{
	public GameObject Over;
	public GameObject Game;
	private int hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Enemy"))
		{
			hp -= 10;
			Destroy(other.gameObject);
			Score.inst.score += 5;
			if(hp<0){
				Over.SetActive(true);
				Debug.Log("You Lose");
				Game.SetActive(false);
			}
			// Destroy(other.GetComponent<MoveToWayPoints>().hp);
		}
	}
}
