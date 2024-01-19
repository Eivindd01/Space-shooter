using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth; //Apelle du script
    public int damage = 1;
    [SerializeField]
    PlayerControler player;

    [SerializeField]
    MissileCreator missileCreator;

    void Start()
    {
        player = PlayerControler.instance;
        StartCoroutine(FireCorut());
    }

    void Update()
    {
        if (player == null) return; //Si player n'existe pas 
        var dir = player.transform.position - transform.position; // dir = destination - origin
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    IEnumerator FireCorut()
    {
        while (true)
        {
            if (player == null) yield break; //Casse la boucle
            var dir = player.transform.position - transform.position;
            missileCreator.Shoot(dir, OnShootImpact);
            yield return new WaitForSeconds(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") //Si le tag est player , fait des damage
        {
            playerHealth.TakeDamage(damage); //damage étant la valeur donnée au dessus
        }
    }

    void OnShootImpact(Collider2D Collider)
    {
        Debug.Log(Collider.gameObject.name);
        Collider.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}

