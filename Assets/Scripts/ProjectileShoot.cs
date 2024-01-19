using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{   
    public string Tag;
    public delegate void OnProjectileCollide(Collider2D collider);
    public OnProjectileCollide onProjectileCollide;

    public Vector3 dir;

    public float speed;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tag))
        {
            if (onProjectileCollide != null) onProjectileCollide(collision);
        }
        
        else if (collision.gameObject.tag == "Boundaries") Destroy(this.gameObject);

        /*switch(collision.gameObject.tag) //Exemple de case
        {
            case "Player": break;

        }
        */
    }

    private void Update()
    {
        transform.position = transform.position + (dir * Time.deltaTime * speed);
    }

   
}