using System.Linq;
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
        RestoreInventory(StarterData.STARTER_INVENTORY);
    }

    void RestoreInventory(Inventory inventory)
    {
        if (!inventory.ActiveQuest.HasValue)
        {
            ActiveQuestTitle.text = "No Quest Selected";
            NextChunkTitle.text = "No Quest Selected";
        } else
        {
            ActiveQuestTitle.text = inventory.ActiveQuest.Value.Title;
            Chunk? activeChunk = inventory.GetActiveChunk();
            if (!activeChunk.HasValue)
            {
                NextChunkTitle.text = "No Item Selected";
            } else
            {
                NextChunkTitle.text = activeChunk.Value.Title;
                SetActiveChunk(activeChunk.Value.Model);
            }
        }
    }

    void SetActiveChunk(GameObject activeChunkModel)
    {
        foreach (int idx in Enumerable.Range(0, NextChunkModel.transform.childCount))
        {
            Destroy(NextChunkModel.transform.GetChild(idx));
        }

        var item = Instantiate(activeChunkModel, Vector3.zero, Quaternion.identity, NextChunkModel.transform);
        item.SetActive(true);

        item.transform.localPosition = Vector3.zero;
        var transformSize = 50 / item.GetComponent<MeshFilter>().mesh.bounds.size.x;
        item.transform.localScale = new Vector3(transformSize, transformSize, transformSize);
    }
}