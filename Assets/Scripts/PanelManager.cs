using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField]
    protected Text ActiveQuestTitle;

    [SerializeField]
    protected Text NextChunkTitle;
    [SerializeField]
    protected Text NextChunkDistance;
    [SerializeField]
    protected GameObject NextChunkModel;
    [SerializeField]
    protected Button NextChunkButton;

    // Start is called before the first frame update
    void Start()
    {
        LoadInformationFromStorage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetQuestTitle(string title)
    {
        ActiveQuestTitle.text = title;
    }

    void LoadInformationFromStorage()
    {
        Debug.Log(Application.persistentDataPath);

    }

    void RestoreInventory(Inventory inventory)
    {
        if (inventory.ActiveQuest == null)
        {
            ActiveQuestTitle.text = "No Quest Selected";
            NextChunkTitle.text = "No Quest Selected";
            return;
        } else
        {
            ActiveQuestTitle.text = inventory.ActiveQuest.Title;
        }
    }


}


struct Inventory
{
    public Quest? ActiveQuest;
    public int? ActiveChunkIndex;
}

struct Quest
{
    public readonly string Title;
    public readonly List<Chunk> Chunks;
}

struct Chunk
{
    readonly string Title;
    readonly GameObject Model;
    LocationInfo Location;
}