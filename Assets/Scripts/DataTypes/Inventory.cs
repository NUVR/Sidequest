using UnityEngine;

struct Inventory
{
    public Quest? ActiveQuest;
    public int ActiveChunkIndex;

    public Inventory(Quest? DefaultActiveQuest)
    {
        ActiveQuest = DefaultActiveQuest;
        ActiveChunkIndex = 0;
    }

    public Chunk? GetActiveChunk()
    {
        if (!ActiveQuest.HasValue || ActiveChunkIndex >= ActiveQuest.Value.Chunks.Count)
        {
            return null;
        }

        return ActiveQuest.Value.Chunks[ActiveChunkIndex];
    }

    public LocationInfo? GetNextLocation()
    {
        Chunk? ActiveChunk = GetActiveChunk();
        if (!ActiveChunk.HasValue)
        {
            return null;
        }
        return ActiveChunk.Value.Location;
    }
}



