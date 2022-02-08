using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;

    public float detonateTime = 3;
    public float radius = 1;

    public GameObject explosionFX;

    // Update is called once per frame
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("Explode", detonateTime);
        Invoke("EnableCollider", .2f);
    }

    public void Initialize(int power)
    {
        rb.AddForce(transform.right * (power / 4), ForceMode2D.Impulse);
    }

    void EnableCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    void Explode()
    {
        
    }

    void SpawnExplosionFX()
    {
        
    }

    void DoCameraShake()
    {
        Camera.main.GetComponent<CameraShake>().shakeDuration = 0.2f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject insExpl = Instantiate(explosionFX, transform.position, Quaternion.identity);
        insExpl.transform.localScale *= radius * radius;
        Destroy(insExpl);
        TerrainDestroyer.instance.DestroyTerrain(transform.position, radius);
        SpawnExplosionFX();
        DoCameraShake();
        Destroy(gameObject);
    }
}
