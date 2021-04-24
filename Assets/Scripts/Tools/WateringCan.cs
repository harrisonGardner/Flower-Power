using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for adding water the plots.
/// </summary>
/// <author>Harrison Gardner</author>
public class WateringCan : MonoBehaviour
{
    public SpriteFetcher.ToolType tool = SpriteFetcher.ToolType.WATERINGCAN;

    public static bool holding = false;
    public static bool useTool = false;

    public int itemUseDelay = 30;
    public static int itemUseTimer = 0;

    private Vector3 defaultPosition;

    public GameObject toolDrag;
    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            DropTool();

        if (Input.GetMouseButtonDown(0) && holding)
            useTool = true;
        if (Input.GetMouseButtonUp(0))
            useTool = false;
    }

    void FixedUpdate()
    {
        if (holding == true)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            toolDrag.transform.position = new Vector3(mousePosition.x, mousePosition.y, -1);
            if (!useTool)
            {
                toolDrag.GetComponent<SpriteRenderer>().sprite =
                    SpriteFetcher.GetSpriteTool(tool, false);
            }
            else if (useTool)
            {
                UseTool();
            }
        }
        else
        {
            toolDrag.transform.position = Vector3.MoveTowards(toolDrag.transform.position, defaultPosition, 0.2f);
            toolDrag.GetComponent<SpriteRenderer>().sprite =
                SpriteFetcher.GetSpriteTool(tool, false);
        }
    }

    private void UseTool()
    {
        toolDrag.GetComponent<SpriteRenderer>().sprite =
                SpriteFetcher.GetSpriteTool(tool, true);
    }

    public static void DropTool()
    {
        holding = false;
    }

    private void OnMouseDown()
    {
        if (!holding)
        {
            Clippers.DropTool();
            SeedPouch.DropTool();
            itemUseTimer = itemUseDelay;
            holding = true;
        }
        else
        {
            DropTool();
        }
    }
}
