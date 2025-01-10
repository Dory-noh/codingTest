using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawnRule
{
    public int day;
    public string tag;
    public int time;
    public bool respawnFlag;
}
public class devil_manager : MonoBehaviour
{
    public Dictionary<int, EnemySpawnRule> enemySpawnRules = new Dictionary<int, EnemySpawnRule>();
    public GameObject devil_prefab;
    float time;
    float speed;
    public GameObject nest;
    ani_manager aniManager;
    int day;
    string enemy_name = "";
    // Start is called before the first frame update
    void Start()
    {
        nest = GameObject.FindGameObjectWithTag("nest");
        
            enemySpawnRules.Add(1, new EnemySpawnRule { day = 1, tag = "enemy_gull", time = 3, respawnFlag = true });
            enemySpawnRules.Add(3, new EnemySpawnRule { day = 3, tag = "enemy_fox", time = 20, respawnFlag = true });
            enemySpawnRules.Add(8, new EnemySpawnRule { day = 8, tag = "enemy_pelican", time = 40, respawnFlag = true });
        aniManager = GameObject.FindGameObjectWithTag("ani_manager").GetComponent<ani_manager>();


    }

    // Update is called once per frame
    void Update()
    {
        day = aniManager.day;
        if(day<=8) CheckEnemySpawn();
    }
    void CheckEnemySpawn()
    {

        if (enemySpawnRules.ContainsKey(day))
        {
            EnemySpawnRule rule = enemySpawnRules[day];
            if (day == rule.day && devil_prefab.CompareTag(rule.tag) && rule.respawnFlag)
            {
                enemy_name = rule.tag;
                respawn_devil_repeat();
                time = rule.time;
                rule.respawnFlag = false;
            }
        }
           
    }

    IEnumerator respawn_devil()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            
            float y = Random.Range(-0.5f, 2);
            GameObject devil = Instantiate(devil_prefab);
            devil.transform.name = enemy_name;
            devil.transform.position = new Vector3(41, y, 0.35f);
            yield return new WaitForSeconds(time);
            if(time > 0.5f) time -= 0.1f;
        }

        
        
        
    }
    void respawn_devil_repeat()
    {
        StartCoroutine(respawn_devil());
    }

    
}
