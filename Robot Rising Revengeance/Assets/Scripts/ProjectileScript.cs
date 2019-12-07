using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 10;
    private float currlifeTime = 0;
    public float lifeTime = 10;
    private Vector3 direction = Vector3.zero; 

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Projectile";
    }

    // Update is called once per frame
    void Update()
    {
        currlifeTime += Time.deltaTime;
        if (currlifeTime >= lifeTime)
        {
            Destroy(gameObject);
        }

        transform.position += direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    void OnCollisionStay(Collision collision)
    {
        Destroy(gameObject);
    }

    public void Initialize(Vector3 dir)
    {
        direction = dir;
    }
}
