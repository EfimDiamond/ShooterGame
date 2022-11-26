using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageDealer 
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float damage;
    private Rigidbody2D rb;
  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

    void Update()
    {
        if (!gameObject)
            return;
        if (rb.transform.position.x < -10) {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out IDamageable damageable))
        {
            DealDamage(damageable);
            gameObject.SetActive(false);
        }
    }

    public void DealDamage(IDamageable damageable)
    {
        damageable.TakeDamage(damage);
    }
}
