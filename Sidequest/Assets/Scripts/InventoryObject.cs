using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject
{
  private CollectibleObject collectibleObject;

  InventoryObject(CollectibleObject collectibleObject)
  {
    this.collectibleObject = collectibleObject;
  }
}
