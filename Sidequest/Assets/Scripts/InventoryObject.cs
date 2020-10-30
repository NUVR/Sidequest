using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject
{
  private InteractableObject interactableObject;

  public InventoryObject(InteractableObject interactableObject)
  {
    this.interactableObject = interactableObject;
  }

  public int GetId() {
    return interactableObject.id;
  }
}
