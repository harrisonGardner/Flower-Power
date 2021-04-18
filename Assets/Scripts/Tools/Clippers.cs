using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clipper object that is used for cutting down flowers.
/// </summary>
/// <author>Harrison Gardner</author>
public class Clippers : MonoBehaviour
{
    public SpriteFetcher.ToolType tool = SpriteFetcher.ToolType.CLIPPERS;

    public static bool holding = false;
    public static bool useTool = false;

    public int itemUseDelay = 120;
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
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))
            DropTool();
        if (holding == true)
        {
            if (!useTool)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                toolDrag.transform.position = new Vector3(mousePosition.x, mousePosition.y, -1);
                itemUseTimer = itemUseDelay;
                toolDrag.GetComponent<SpriteRenderer>().sprite =
                    SpriteFetcher.GetSprite(tool, false);
            }
            else if(itemUseTimer > 0)
            {
                UseTool();
            }
            else
            {
                useTool = false;
            }
        }
        else
        {
            useTool = false;
            toolDrag.transform.position = Vector3.MoveTowards(toolDrag.transform.position, defaultPosition, 0.2f);
            toolDrag.GetComponent<SpriteRenderer>().sprite =
                SpriteFetcher.GetSprite(tool, false);
        }
    }

    private void UseTool()
    {
        toolDrag.GetComponent<SpriteRenderer>().sprite =
                SpriteFetcher.GetSprite(tool, true);
        itemUseTimer--;
    }

    public static void DropTool()
    {
        holding = false;
        itemUseTimer = 0;
    }

    private void OnMouseDown()
    {
        if (!holding)
        {
            WateringCan.DropTool();
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
