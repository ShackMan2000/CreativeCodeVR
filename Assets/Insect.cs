using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insect : MonoBehaviour
{
    private Vector3 target;
    public float roamRadius;
    public Vector3 roamCenter;
    public float speed = 1.0f;
    public float lifeTime = 5.0f;

    void Start()
    {
        PickRandomDestination();

        StartCoroutine(DestroyAfterSeconds(lifeTime));
    }

    public void Initialize(float roamRadius, Vector3 roamCenter, float speed, float lifeSpan)
    {
        this.roamRadius = roamRadius;
        this.roamCenter = roamCenter;
        this.speed = speed;
    }

    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            PickRandomDestination();
        }
    }

    public void PickRandomDestination() {
        target = (Random.insideUnitSphere * 5) + roamCenter;
    }

    IEnumerator DestroyAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
