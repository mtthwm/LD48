// using UnityEngine;
// using UnityEditor;
// using System.Collections.Generic;
// using UnityEditor.IMGUI.Controls;
// using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

// [CustomEditor(typeof(MeleeAttackManager))]
// public class MeleeAttackKeyFrameEditor : Editor
// {
//     static SerializedProperty list;
//     static int listLength = 0;
//     static ColliderFrameEditor[] colliderEditors;

//     static void SetupColliders ()
//     {
//         // Debug.Log(colliderEditors);
//         Debug.Log(listLength);
//         colliderEditors = new ColliderFrameEditor[listLength];
//         for (int i = 0; i < listLength; i++)
//         {
//             colliderEditors[i] = new ColliderFrameEditor();
//         } 
//     }

//     class ColliderFrameEditor : BoxBoundsHandle
//     {
//         protected override Bounds OnHandleChanged(HandleDirection handle, Bounds boundsOnClick, Bounds newBounds)
//         {
//             SetupColliders();
//             return base.OnHandleChanged(handle, boundsOnClick, newBounds);
//         }
//     }

//     void OnEnable()
//     {
//         SetupColliders();
//     }



//     public override void OnInspectorGUI () {
//         serializedObject.Update();
//         list = serializedObject.FindProperty("keyFrames");
// 		EditorGUILayout.PropertyField(list, false);
//         EditorGUI.indentLevel += 1;
//         if (list.isExpanded) 
//         {
//             for (int i = 0; i < list.arraySize; i++)
//             {
//                 listLength = list.arraySize;
//                 EditorGUILayout.LabelField("Frame: ", i.ToString());
//                 EditorGUI.indentLevel += 1;
//                 EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i).FindPropertyRelative("seconds"));
//                 EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i).FindPropertyRelative("height"));
//                 EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i).FindPropertyRelative("width"));
//                 EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i).FindPropertyRelative("position"));
//                 EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i).FindPropertyRelative("rotation"));
//                 EditorGUI.indentLevel -= 1;
//             } 
//         }
//         EditorGUI.indentLevel -= 1;
// 		serializedObject.ApplyModifiedProperties();
//     }

//     protected virtual void OnSceneGUI() {
//         MeleeAttackManager Target = (MeleeAttackManager)target;
//         if (colliderEditors != null) {
//             for (int i = 0; i < colliderEditors.Length; i++)
//             {
//                 MeleeAttackKeyFrame frame = Target.keyFrames[i];
//                 ColliderFrameEditor boxBounds = colliderEditors[i];
//                 boxBounds.center = frame.position;
//                 boxBounds.size = new Vector3(frame.width, frame.height);
//                 boxBounds.SetColor(new Color(1f, 0f, 0f, 0.5f));
//                 EditorGUI.BeginChangeCheck();
//                 boxBounds.DrawHandle();
//                 if (EditorGUI.EndChangeCheck())
//                 {
//                     Undo.RecordObject(Target, "Change Bounds");
//                     Debug.Log(boxBounds);
//                     frame.height = boxBounds.size.y;
//                     frame.width = boxBounds.size.x;
//                     frame.position = boxBounds.center;
//                 }
//             }
//         }
//     }
// }
 