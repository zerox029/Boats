using UnityEngine;
using UnityEditor;
using System.Collections;

public class EnemyDesignerWindow : EditorWindow {

    [MenuItem("Window/EnemyDesigner")]
	static void OpenWindow()
    {
        EnemyDesignerWindow window = (EnemyDesignerWindow)GetWindow(typeof(EnemyDesignerWindow));
        window.minSize = new Vector2(600, 300);
        window.Show();
    }

}
