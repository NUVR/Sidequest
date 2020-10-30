using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponent<InteractableObject>()!=null)
                {
                    InteractableObject obj = hit.transform.GetComponent<InteractableObject>();
                    obj.isPicked = true;
                    obj.target = transform;
                    obj.GetComponent<BoxCollider>().enabled = false;
                    string data = "";
                    data += obj.id.ToString() + "," + obj.name + "," + obj.description+","+thumbnail_Unravel(obj.thumbnail)+"|";
                    PlayerPrefs.SetString(obj.id.ToString() + " SaveObject", data);
                    
                }
            }
        }
    }
    public string thumbnail_Unravel(Sprite sprite)
    {
        return sprite.name;
        
    }
}
