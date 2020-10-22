using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{


    [HideInInspector]
    public bool isPicked = false;
    [HideInInspector]
    public Transform target;
    [HideInInspector]
    float speed = 1;
    [HideInInspector]
    public float acceleration = 0.1f;
    [HideInInspector]
    public float minDistance = 0.1f;

    public int id;
    public string name;
    public string description;
    public Sprite thumbnail;


    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (isPicked&&target!=null)
        {
            speed += acceleration;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
            if (Vector3.Distance(transform.position, target.transform.position) < minDistance)
            {
                gameObject.SetActive(false);
            }
        }
    }

    
}
