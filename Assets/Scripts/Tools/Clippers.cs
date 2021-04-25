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

    public GameObject orderGameObject;
    public Order order;

    public int itemUseDelay = 30;
    public static int itemUseTimer = 0;

    private Vector3 defaultPosition;

    public GameObject toolDrag;
    public AudioSource toolSound;

    // Start is called before the first frame update
    void Start()
    {
        order = orderGameObject.GetComponent<Order>();
        defaultPosition = new Vector3(transform.position.x, transform.position.y, -2);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            DropTool();
        if (Input.GetMouseButtonDown(0))
        {
            itemUseTimer = itemUseDelay;
        }
    }

    void FixedUpdate()
    {
        if (holding == true)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            toolDrag.transform.position = new Vector3(mousePosition.x, mousePosition.y, -2);
            if (!useTool)
            {
                itemUseTimer = itemUseDelay;
                toolDrag.GetComponent<SpriteRenderer>().sprite =
                    SpriteFetcher.GetSpriteTool(tool, false);
            }
            else if (itemUseTimer >= itemUseDelay)
            {
                toolDrag.GetComponent<SpriteRenderer>().sprite =
                    SpriteFetcher.GetSpriteTool(tool, false);
                toolSound.Play();
                itemUseTimer--;
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
                SpriteFetcher.GetSpriteTool(tool, false);
        }
    }

    private void UseTool()
    {
        toolDrag.GetComponent<SpriteRenderer>().sprite =
                SpriteFetcher.GetSpriteTool(tool, true);
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
