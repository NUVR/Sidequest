using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDatabase : ScriptableObject
{
  public GameObject testObject;

  private List<CollectibleObject> items = new List<CollectibleObject>();

  private void Awake()
  {
    items.Add(new CollectibleObject(0, "test object", "A not-so-fancy object for testing", Resources.Load<Sprite>("Sprites/test.jpg"), testObject));
  }

  void Start()
  {
    Debug.Log(items);
  }
}
