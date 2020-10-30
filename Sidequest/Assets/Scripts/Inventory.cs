using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Inventory", fileName = "Inventory.asset")]
public class Inventory : ScriptableObject
{
  private const string saveFileName = "gamesave.save";

  private List<InventoryObject> collectedObjects = new List<InventoryObject>();

  public void LoadGame()
  {
    if (File.Exists(Application.persistentDataPath + "/" + saveFileName))
    {
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Open(Application.persistentDataPath + "/" + saveFileName, FileMode.Open);
      InventorySave save = (InventorySave)bf.Deserialize(file);
      file.Close();

      try
      {
        save.collectedObjectIds.ForEach(id => collectedObjects.Add(new InventoryObject(ObjectDatabase.Instance.GetItemById(id))));
      }
      catch (System.NullReferenceException)
      {
        Debug.Log("Failed to load save - skipping");
      }

      Debug.Log("Game loaded from save");
    }
    else
    {
      Debug.Log("Found no save file");
    }
  }

  public void SaveGame()
  {
    InventorySave save = BuildInventorySave();

    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(Application.persistentDataPath + "/" + saveFileName);
    bf.Serialize(file, save);
    file.Close();

    Debug.Log("Game saved");
  }

  private InventorySave BuildInventorySave()
  {
    InventorySave save = new InventorySave();
    collectedObjects.ForEach(inventoryObject => save.collectedObjectIds.Add(inventoryObject.GetId()));

    return save;
  }

  public void AddItem(InteractableObject interactableObject)
  {
    collectedObjects.Add(new InventoryObject(interactableObject));
  }
}
