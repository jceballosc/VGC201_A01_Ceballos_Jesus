using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public GameObject ProjectilePrefab2;
    public Transform spawnLoc;

    public void FireProjectile(int power)
    {
        GameObject shot = Instantiate(ProjectilePrefab, spawnLoc.transform.position, spawnLoc.transform.rotation);
        shot.GetComponent<PlayerProjectile>().Initialize(power);
    }

    public void FireProjectileBomb(int power)
    {
        GameObject shot = Instantiate(ProjectilePrefab2, spawnLoc.transform.position, spawnLoc.transform.rotation);
        shot.GetComponent<Projectile>().Initialize(power);
    }

}
