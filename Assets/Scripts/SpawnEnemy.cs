using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private EnemyController enemyPrifab;
    [SerializeField] private float time;
    private Vector2 screen;

    void Start()
    {
        StartCoroutine(SpawnRout());
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        EnemyController enemy = Instantiate(enemyPrifab);
        enemy.transform.position = new Vector3(screen.x, Random.Range(-screen.y, screen.y));
    }

    IEnumerator SpawnRout()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            Spawn();
        }
    }
}