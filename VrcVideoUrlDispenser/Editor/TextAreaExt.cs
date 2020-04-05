using UnityEngine;

/// <summary>
/// コピー&ペーストをサポートするTextArea拡張
/// </summary>
public class TextAreaExt
{
	/// <summary>
	/// TextArea with copy-paste support
	/// </summary>
	/// <param name="value"></param>
	/// <param name="options"></param>
	/// <returns></returns>
	public static string TextArea(string value, params GUILayoutOption[] options)
	{
		var textFieldID = GUIUtility.GetControlID("TextArea".GetHashCode(), FocusType.Keyboard) + 1;
		if (textFieldID == 0)
		{
			return value;
		}

		value = HandleCopyPaste(textFieldID) ?? value;

		return GUILayout.TextArea(value, options);
	}

	/// <summary>
	/// Add copy-paste functionality to any TextArea
	/// Returns changed text or NULL.
	/// Usage: text = HandleCopyPaste (controlID) ?? text;
	/// </summary>
	/// <param name="controlID"></param>
	/// <returns></returns>
	public static string HandleCopyPaste(int controlID)
	{
		if (controlID != GUIUtility.keyboardControl)
		{
			return null;
		}

		if (Event.current.type == EventType.KeyUp && (Event.current.modifiers == EventModifiers.Control || Event.current.modifiers == EventModifiers.Command))
		{
			if (Event.current.keyCode == KeyCode.C)
			{
				Event.current.Use();
				var editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
				editor.Copy();
			}
			else if (Event.current.keyCode == KeyCode.V)
			{
				Event.current.Use();
				var editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
				editor.Paste();
				return editor.text;
			}
		}

		return null;
	}
}
