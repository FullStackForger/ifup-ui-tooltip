using UnityEngine;
using System.Collections;

namespace ifup.ui { 
    /// <summary>
    /// Tooltip controller displays short info using UGUI.
    /// It can be attached to any game object.
    /// 
    /// TODO:
    ///  - glyph support
    ///  - custom text color support
    ///  - custom compoment inspector 
    ///
    /// </summary>
    public class TooltipController : MonoBehaviour 
    {
	    public string message = "";
	    public bool ignoreUGUI = false;

	    private TooltipManager tooltip { get { return TooltipManager.Instance; } }

	    void OnMouseOver()
	    {			
		    if (ignoreUGUI || isInteractive) {
			    tooltip.Show(message);
		    } else {
			    tooltip.Hide();
		    }
	    }

	    void OnMouseExit()
	    {
		    tooltip.Hide();
	    }

	    private static bool isInteractive 
	    { 
		    get {
			    return (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject());
		    }
	    }
    }
}