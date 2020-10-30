using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDatabase : ScriptableObject
{
  private Dictionary<int, InteractableObject> items = new Dictionary<int, InteractableObject>();

  private static ObjectDatabase _instance;
  public static ObjectDatabase Instance
  {
    get
    {
      if (!_instance)
      {
        ObjectDatabase[] tmp = Resources.FindObjectsOfTypeAll<ObjectDatabase>();
        if (tmp.Length > 0)
        {
          _instance = tmp[0];
        }
        else
        {
          _instance = new ObjectDatabase();
        }
      }

      return _instance;
    }
  }

  private void Awake()
  {
    items.Add(0, new InteractableObject(0, "test object", "A not-so-fancy object for testing", Resources.Load<Sprite>("Sprites/test.jpg")));
  }

  void Start()
  {
    Debug.Log(items);
  }

  public InteractableObject GetItemById(int id)
  {
    return items[id];
  }
}
