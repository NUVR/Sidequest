using UnityEngine;

struct Chunk
{
    public readonly string Title;
    public readonly GameObject Model;
    public LocationInfo Location;

    public Chunk(string Title, GameObject Model, LocationInfo Location)
    {
        this.Title = Title;
        this.Model = Model;
        this.Location = Location;
        
        this.Model.SetActive(false);
    }
}