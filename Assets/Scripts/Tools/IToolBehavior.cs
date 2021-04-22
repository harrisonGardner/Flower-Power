using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IToolBehavior
{
    public void UseTool();
    public void DropTool();


    public bool MakeActive();
}
