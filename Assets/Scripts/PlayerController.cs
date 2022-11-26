using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 10f;
    private Health health;
    
    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        health.OnOutOfHealth += Die;
    }

    private void OnDisable()
    {
        health.OnOutOfHealth -= Die;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
	float y = Input.GetAxis("Vertical");
	Vector2 input = new Vector2(x, y);
	Vector2 velocity = input * speed;
	transform.Translate(velocity * Time.deltaTime);

    }
    public void Heal()
    {
        health.Heal();
    }
    private void Die()
    {
        gameObject.SetActive(false);
    }

}
