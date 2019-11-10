using System.Collections.Generic;
using UnityEngine;

public static class StarterData
{
    static readonly Chunk CHUNK_ONE = new Chunk("One Chonker", GenerateCubeWithName("One Chonker"), new LocationInfo());
    static readonly Chunk CHUNK_TWO = new Chunk("Chonky Boi", GenerateCubeWithName("Chonky Boi"), new LocationInfo());
    static readonly Chunk CHUNK_THREE = new Chunk("Big Chonk", GenerateCubeWithName("Big Chonk"), new LocationInfo());

    static readonly Quest STARTER_QUEST = new Quest("Find the Chonks", new List<Chunk>{ CHUNK_ONE, CHUNK_TWO, CHUNK_THREE } );

    internal static Inventory STARTER_INVENTORY = new Inventory(STARTER_QUEST);

    static GameObject GenerateCubeWithName(string Name)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = Name;
        cube.transform.localScale.Set(10, 10, 10);
        return cube;
    }
}
