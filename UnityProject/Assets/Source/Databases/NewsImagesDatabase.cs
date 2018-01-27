using System.Collections.Generic;
using UnityEngine;

public static class NewsImagesDatabase
{
    private static Dictionary<string, Sprite> spritesDictionary = new Dictionary<string, Sprite>();
    private static bool databaseLoaded = false;

    public static void LoadDatabase()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("NewsPhotos");

        foreach (var sprite in sprites)
        {
            if (!spritesDictionary.ContainsKey(sprite.name))
            {
                spritesDictionary.Add(sprite.name, sprite);
            }
        }

        databaseLoaded = true;
    }

    public static Sprite GetImage(string spriteName)
    {
        if (!databaseLoaded)
        {
            LoadDatabase();
        }

        if (spritesDictionary.ContainsKey(spriteName))
        {
            return spritesDictionary[spriteName];
        }

        return null;
    }
}
