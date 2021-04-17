using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clippers : MonoBehaviour
{
    public SpriteFetcher.ToolType tool = SpriteFetcher.ToolType.CLIPPERS;

    public static bool holding = false;
    public static bool useTool = false;

    public int itemUseDelay = 120;
    public int itemUseTimer = 0;

    private Vector3 defaultPosition;

    public GameObject toolDrag;
    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (holding == true || itemUseTimer > 0)
        {
            if (!useTool)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                toolDrag.transform.position = new Vector3(mousePosition.x, mousePosition.y, -1);
                itemUseTimer = itemUseDelay;
            }
            else
            {
                UseTool();
            }
        }
        else
        {
            useTool = false;
            toolDrag.transform.position = defaultPosition;
            toolDrag.GetComponent<SpriteRenderer>().sprite =
                SpriteFetcher.GetSprite(tool, false);
        }
    }

    private void UseTool()
    {
        holding = false;
        toolDrag.GetComponent<SpriteRenderer>().sprite =
                SpriteFetcher.GetSprite(tool, true);
        itemUseTimer--;
    }

    private void OnMouseDown()
    {
        if (!holding && !WateringCan.holding && !SeedPouch.holding)
        {
            itemUseTimer = itemUseDelay;
            holding = true;
        }
    }
}
