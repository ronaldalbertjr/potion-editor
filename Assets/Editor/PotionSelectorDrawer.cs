using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(PotionSelectorAttribute))]
public class PotionSelectorDrawer : PropertyDrawer
{
    int index;
    string[] potionNames = new string[PotionDB.Instance.potions.Length];
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        for (int i = 0; i < PotionDB.Instance.potions.Length; i++)
        {
            potionNames[i] = PotionDB.Instance.potions[i].name;
            if(potionNames[i] == property.FindPropertyRelative("name").stringValue)
            {
                index = i;
            }
        }
        Rect popUpRect = new Rect(position.x, position.y, position.width, position.height);
        index = EditorGUI.Popup(popUpRect, "Potions:", index, potionNames);

        property.FindPropertyRelative("name").stringValue = PotionDB.Instance.potions[index].name;
        property.FindPropertyRelative("heal").intValue = PotionDB.Instance.potions[index].heal;
    }
        
}
