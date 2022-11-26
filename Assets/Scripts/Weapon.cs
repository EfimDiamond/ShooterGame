using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] Transform projecttileSpawnPoint;
    [SerializeField] float fireRate;
    [SerializeField] int totalAmmo;
    

    private bool isOnCooldown = false;
    private IEnumerator ColdownRoutin() {
        isOnCooldown = true;
        while (isOnCooldown) {
            yield return new WaitForSeconds(fireRate);
            isOnCooldown = false;
        }
    }

    public void Shoot() {
        if (isOnCooldown)
            return;
        Projectile projectile = GameObject.Instantiate(projectilePrefab);
        projectile.transform.position = projecttileSpawnPoint.position;
        projectile.transform.SetParent(null);
        projectile.gameObject.SetActive(true);
        projectile.MoveInDirection(transform.right);

        StartCoroutine(ColdownRoutin());
    }

  
}
