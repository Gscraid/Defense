using UnityEngine;
using System.Collections;

public class TowerPlace : MonoBehaviour {
	public GameObject Tower;
	public Transform towerRotation;
	public Vector3 offset;
	public GameObject curTower;
	public bool empty = true;
	void OnMouseDown()
	{
		if(empty)
		{
			curTower = GameObject.Instantiate(Tower,transform.position+offset,towerRotation.rotation) as GameObject;
			empty = false;
		}
	}

}
