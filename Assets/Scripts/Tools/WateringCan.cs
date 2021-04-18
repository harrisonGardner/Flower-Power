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
            else if (itemUseTimer > 0)
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
            toolDrag.transform.position = defaultPosition;
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
