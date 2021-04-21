using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour, IUpdateController
{
    IToolBehavior activeTool;
    IList<IToolBehavior> tools;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActionOnUpdate()
    {
        // SWITCH ACTIVE TOOL?

        // OR USE ACTIVE TOOL?
    }

}
