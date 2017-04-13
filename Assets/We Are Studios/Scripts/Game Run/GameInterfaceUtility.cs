using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Misc utility functions used by other scripts 
 */
public class GameInterfaceUtility {
	
	public static void SetBackground(GUIStyle style, Texture2D background) {
		style.normal.background = background;
		style.active.background = background;
		style.hover.background = background;
		style.focused.background = background;
	}

	public static void SetTextColor(GUIStyle style, Color color) {
		style.normal.textColor = color;
		style.active.textColor = color;
		style.hover.textColor = color;
		style.focused.textColor = color;
	}
}
