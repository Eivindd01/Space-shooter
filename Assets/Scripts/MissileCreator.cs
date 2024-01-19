using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCreator : MonoBehaviour
{
    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    public float speed;


    public void Shoot(Vector3 dir, ProjectileShoot.OnProjectileCollide onProjectileCollide)
    {      
        GameObject go = Instantiate(projectilePrefab); //go = GameObject
        go.transform.position = transform.position;      
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        go.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        ProjectileShoot proj = go.GetComponent<ProjectileShoot>();
        proj.onProjectileCollide = onProjectileCollide;
        proj.dir = dir;
        proj.speed = speed;
    }
}
