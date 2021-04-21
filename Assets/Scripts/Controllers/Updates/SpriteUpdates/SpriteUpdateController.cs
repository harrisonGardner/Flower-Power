using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpriteUpdateController : MonoBehaviour, IUpdateController
{
    // LIST of GAME OBJECTS w/ SPRITES to UPDATE & CURRENT STATE of LIST
    static int numGameObjects = 0;
    public static IList<ISpriteUpdate> spritesToRedraw = new List<ISpriteUpdate>();


    // WAY to UNIVERSALLY ADD ELEMENTS to the LIST
    // WHAT INFO DO WE NEED TO UPDATE THE SPRITE?
    // GAME OBJECT

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

        throw new System.NotImplementedException();
    }


    //Temp Updater
    public static void TempSpriteUpdate()
    {
        // DOES THE GAME OBJECT have a componenet that implements the IUpdateSprite interface?
        if (spritesToRedraw.Count > 0)
        {
            // ITERATE through LIST to UPDATE SPRITES
            foreach (ISpriteUpdate needsRedraw in spritesToRedraw)
            {
                needsRedraw.SpriteUpdate();
            }

            // REMOVE ELEMENTS from LIST AFTER UPDATES
            spritesToRedraw = new List<ISpriteUpdate>();
        }
        //throw new System.NotImplementedException();
    }
}
