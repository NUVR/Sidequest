using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject
{
  private int id;
  private string name;
  private string description;

  private Sprite thumbnail;

  private GameObject obj;

  public CollectibleObject(int id, string name, string description, Sprite thumbnail, GameObject obj)
  {
    this.id = id;
    this.name = name;
    this.description = description;
    this.thumbnail = thumbnail;
    this.obj = obj;
  }
}
