using System.Collections.Generic;

struct Quest
{
    public readonly string Title;
    public readonly List<Chunk> Chunks;

    public Quest(string Title, List<Chunk> Chunks = null)
    {
        this.Title = Title;
        this.Chunks = Chunks ?? new List<Chunk>();
    }
}