using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    float horizontal;
    float vertical;

    [SerializeField]
    float moveSpeed = 10;

    [SerializeField]
    MissileCreator missileCreator;

    private Rigidbody2D rb;
    private bool fire;

    [SerializeField]
    private float fireCooldown =1;
    private float lastFireTime;

    public int damage = 1;
    Vector2 direction;

    public static PlayerControler instance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fire) TryShoot();
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        direction = new Vector2(mousePosition.x - transform.position.x  , mousePosition.y - transform.position.y);
        //var dir = player.transform.position - transform.position; // dir = destination - origin       
        GetInput();
    }

    // FixedUpdate is called every fixed frame-rate frame
    private void FixedUpdate()
    {
        Move();
    }

    private void Awake() //Si Awake instancie le PlayerController
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision) //Debug pour voir si la collision marche
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            Debug.Log("Collision détectée");
        }
    }

    void Move()
    {
        Vector3 pos = transform.position; //Vector 3 = 3 valeurs ici hor, movspd, vrtcl
        pos += new Vector3(horizontal * Time.deltaTime * moveSpeed, vertical * Time.deltaTime * moveSpeed, 0);
        rb.MovePosition(pos);

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //Mathf = mathfonction
        //rb.MoveRotation(Quaternion.AngleAxis(angle, Vector3.forward));
        transform.rotation = Quaternion.AngleAxis(angle- 90, Vector3.forward);       
    }

    void GetInput()
    {
        fire = Input.GetAxis("Fire4") == 1 ? true : false; //Deamnde si fire = true 
        horizontal = Input.GetAxis("Horizontal"); 
        vertical = Input.GetAxis("Vertical");
    }

    private void TryShoot() //Ne pas pouvoir tirer si en cooldown
    {
        if (Time.timeSinceLevelLoad - lastFireTime < fireCooldown) return; //return fait que le code du bas ne s'éxecute pas si cooldown
        lastFireTime = Time.timeSinceLevelLoad;
        fire = false;
        missileCreator.Shoot(transform.up, OnEnnemyShoot);       
    }
 
    void OnEnnemyShoot(Collider2D Collider) //Appliquer dégats sur vie de l'ennemi
    {
        Collider.GetComponent<EnnemyHealth>().TakeDamage(damage);
        Debug.Log(Collider.gameObject.name);
    }
}
