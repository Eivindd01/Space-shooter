using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform[] wayPoints; //Pour trouver les waypoints dans FollowThePath

    public static Waypoints instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
