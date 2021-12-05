using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    private GameObject hero;
    private GameObject enemy;
    private float n = 6f;
    private float m = 3f;
    private float speed = 4f;
    public float hp = 100f;
    public Transform[] waypoints;
    private bool IsFight;
    public Animator an;
    int curWaypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Transform tr = GetComponent<Transform
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector3.forward * 4 * Time.deltaTime);
        Vector3 heroPos = transform.position;
        enemy = FindClosestEnemy();
        if(enemy != null)
        {
            Vector3 enemyPos = enemy.GetComponent<Transform>().position;
        
            if(enemy != null && (heroPos-enemyPos).magnitude <= n )
            {
                if((heroPos-enemyPos).magnitude > m)
                    {
                        Go(enemyPos);
                        IsFight = false;
                        an.SetBool("Fight",false);
                    }
                if((heroPos-enemyPos).magnitude <= m)
                   
                   {
                    IsFight = true;
                    an.SetBool("Fight",true);
                    transform.position = Vector3.MoveTowards(transform.position,transform.position + new Vector3(0f, 0, Random.Range(-1, -1)),Time.deltaTime*speed);
                    enemy.GetComponent<EnemyMove>().hp -= 1;
                    if(enemy.GetComponent<EnemyMove>().hp < 0)
                        {
                            an.SetBool("Fight",false);
                            IsFight = false;
                            Score.inst.score += 1;
                        }
                    Debug.Log(enemy.GetComponent<EnemyMove>().hp);
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
    
    
    private void Go(Vector3 enemyPos)
    {
        // Vector3 position = ObjA.position;
        transform.position = Vector3.MoveTowards(transform.position,enemyPos,speed * Time.deltaTime);
        // ObjB.Translate(Vector3.forward * 4*Time.deltaTime);
    }
    public GameObject FindClosestEnemy() {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
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
