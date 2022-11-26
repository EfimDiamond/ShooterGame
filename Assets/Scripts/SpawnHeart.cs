using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeart : MonoBehaviour
{
    [SerializeField] private GameObject heartPrifab;
    [SerializeField] private float time;
    private Vector2 screen;

    void Start()
    {
        StartCoroutine(SpawnRout());
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }


    void Spawn()
    {
        GameObject heart = Instantiate(heartPrifab);
        heart.transform.position = new Vector3(Random.Range((-screen.x+5), (screen.x-5)), Random.Range((-screen.y+5),(screen.y-5)));
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