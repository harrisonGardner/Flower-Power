using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpriteUpdateController : IUpdateController
{
    // LIST of GAME OBJECTS w/ SPRITES to UPDATE & CURRENT STATE of LIST
    static int numGameObjects = 0;
    public static IList<ISpriteUpdate> spritesToRedraw = new List<ISpriteUpdate>();


    // WAY to UNIVERSALLY ADD ELEMENTS to the LIST
    public static void AddSpriteToRedraw(ISpriteUpdate spriteToRedraw)
    {
        if (spriteToRedraw != null)
        {
            spritesToRedraw.Add(spriteToRedraw);
            numGameObjects++;
        }
    }

    public void ActionOnUpdate()
    {
        if (spritesToRedraw.Count > 0)
        {
            // ITERATE through LIST to UPDATE SPRITES

            foreach (ISpriteUpdate needsRedraw in spritesToRedraw)
            {
                if (needsRedraw != null)
                {
                    needsRedraw.SpriteUpdate();
                }
            }

            // REMOVE ELEMENTS from LIST AFTER UPDATES
            spritesToRedraw.Clear();
            numGameObjects = spritesToRedraw.Count;
        }
    }
}
