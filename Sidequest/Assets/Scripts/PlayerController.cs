using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Inventory inventory;

  void Awake()
  {
    inventory.LoadGame();
  }

  public void CollectItem(InteractableObject interactableObject)
  {
    inventory.AddItem(interactableObject);
  }
}
