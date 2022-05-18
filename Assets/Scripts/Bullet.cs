using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject bulletImpactEffect;

    public float explosionRadius = 0f;

    public float speed = 70f;

    public int damage = 50;

    public void Seek(Transform _target)
    {
        target = _target;
    }
    
    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {   
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectInst = (GameObject)Instantiate(bulletImpactEffect, transform.position, transform.rotation);

        
        Destroy(effectInst, 5f);
        Damage(target);
        Destroy(gameObject);
        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        Enemy_Movement e = enemy.GetComponent<Enemy_Movement>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
