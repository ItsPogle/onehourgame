using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject hiteffect;

    private void Start()
    {
        Destroy(this.gameObject, 3);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().health -= 1;
            Instantiate(hiteffect, this.transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
