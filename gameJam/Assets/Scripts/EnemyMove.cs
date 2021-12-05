using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    private GameObject hero;
    private GameObject enemy;
    public Animator an;
    private float n = 6f;
    private float m = 3f;
    private float speed = 5f;
    public float hp = 200;
    public Transform[] waypoints;
    int curWaypointIndex = 0;
    private bool IsFight;
    void Start()
    {

    }


    void Update()
    {

        Vector3 enemyPos = transform.position;
        hero = FindClosestHero();
        if(hero != null)
        {
        	Vector3 heroPos = hero.GetComponent<Transform>().position;
        
        if((enemyPos-heroPos).magnitude <= n)
        	{
        		if((enemyPos-heroPos).magnitude > m)
            		{
                		Go(heroPos);
                        IsFight = false;
                        an.SetBool("Fight",false);
            		}
            	if((enemyPos-heroPos).magnitude <= m)
            		{
                        IsFight = true;
                        an.SetBool("Fight",true);
                        transform.position = Vector3.MoveTowards(transform.position,transform.position + new Vector3(0f, 0f, Random.Range(-1, -1)),Time.deltaTime*speed);
                    	hero.GetComponent<HeroMove>().hp -= 1;
                        if(hero.GetComponent<HeroMove>().hp < 0)
                            {
                                an.SetBool("Fight",false);
                                IsFight = false;
                            }
                    	Debug.Log(hero.GetComponent<HeroMove>().hp);
            		}
            }
        }

        if(curWaypointIndex < waypoints.Length && IsFight == false)
        	{	
        		Vector3 pos = new Vector3(waypoints[curWaypointIndex].position.x,transform.position.y,waypoints[curWaypointIndex].position.z);
        		transform.LookAt(pos);
        		transform.position = Vector3.MoveTowards(transform.position,waypoints[curWaypointIndex].position,Time.deltaTime*speed);
        		//_rb.velocity = new Vector2(waypoints[curWaypointIndex].position.x - transform.position.x, waypoints[curWaypointIndex].position.y - transform.position.y).normalize;
        		if(Vector3.Distance(transform.position,waypoints[curWaypointIndex].position) < 0.5f)
        		{
        			curWaypointIndex++;
        		}
        	}
        if(hp < 0)
        {
        	Destroy(gameObject);
        }
    }

    private void Go(Vector3 heroPos)
    {
        transform.position = Vector3.MoveTowards(transform.position,heroPos,speed * Time.deltaTime);
    }

    public GameObject FindClosestHero() {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Hero");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
      
}
