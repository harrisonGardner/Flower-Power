using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    // FIELD to KEEP TRACK of TIME
    private IList<IBootController> creates = new List<IBootController>();
    private IList<IUpdateController> updates = new List<IUpdateController>();

    void Awake()
    {
        //creates.Add();
    }

    // Start is called before the first frame update
    void Start()
    {
        // ITEREATE THROUGH the IBOOTCONTROLLER CLASSES
            // THEY NEED TO INSTANTIATE RELEVANT OBJECTS (e.g. garden, plot, colors, etc.)
            // THEY ALSO NEED TO ADD RELEVANT IUPDATE CONTROLLERS to the UPDATES list
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
