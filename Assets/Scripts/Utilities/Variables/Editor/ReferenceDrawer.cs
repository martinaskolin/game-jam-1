using UnityEditor;
using UnityEngine;
using Decent;
using System.Linq;

[CustomPropertyDrawer(typeof(FloatReference))]
public class ReferenceDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        // Get properties
        bool useConstant = property.FindPropertyRelative("UseConstant").boolValue;

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        Rect rect = new Rect(position.position, Vector2.one * 20f);

        if (EditorGUI.DropdownButton(rect, new GUIContent(GetTexture()), FocusType.Keyboard, new GUIStyle() 
        { 
            fixedWidth = 50f,
            border = new RectOffset(1,1,1,1)
        }))
        {
            GenericMenu menu = new GenericMenu();
            menu.AddItem(new GUIContent("Constant"), useConstant, () => SetProperty(property, true));
            menu.AddItem(new GUIContent("Variable"), !useConstant, () => SetProperty(property, false));
            menu.ShowAsContext();
        }

        position.position += Vector2.right * 15f;
        float value = property.FindPropertyRelative("ConstantValue").floatValue;

        if (useConstant)
        {
            string newValue = EditorGUI.TextField(position, value.ToString());
            float.TryParse(newValue, out value);
            property.FindPropertyRelative("ConstantValue").floatValue = value;
        }
        else
        {
            EditorGUI.ObjectField(position, property.FindPropertyRelative("Variable"), GUIContent.none);
        }

        EditorGUI.EndProperty();
    }

    private Texture GetTexture()
    {
        //var textures = Resources.FindObjectsOfTypeAll(typeof(Texture)).Cast<Texture>().ToList();
        //    //.Where(t => t.name.ToLower().Contains("animationdopesheetkeyframe"))
        //    //.Cast<Texture>().ToList();

        //return textures[2];

        var texture = new Texture2D(80, 80, TextureFormat.ARGB32, false);
        for (int x = 0; x < 80; x++)
        {
            for (int y = 0; y < 80; y++)
            {
                texture.SetPixel(x, y, Color.blue);
            }
        }

        return texture;
    }

    private void SetProperty(SerializedProperty property, bool value)
    {
        var propRelative = property.FindPropertyRelative("UseConstant");
        propRelative.boolValue = value;
        property.serializedObject.ApplyModifiedProperties();
    }

}
