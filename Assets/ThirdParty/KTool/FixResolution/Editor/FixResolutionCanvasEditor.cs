using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace KTool.FixResolution.Editor
{
	[CustomEditor(typeof(FixResolutionCanvas))]
	public class FixResolutionCanvasEditor : UnityEditor.Editor
	{
        #region Properties
        private FixResolutionCanvas fixResolutionCanvas;
        private SerializedProperty propertyIsDebug;
        private SerializedProperty propertyScreenTemplates;
        private bool isShowScreenTemplates = false;
        #endregion Properties

        #region UnityEvent
        private void OnEnable()
        {
            fixResolutionCanvas = serializedObject.targetObject as FixResolutionCanvas;
            propertyIsDebug = serializedObject.FindProperty("isDebug");
            propertyScreenTemplates = serializedObject.FindProperty("screenTemplates");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            //
            EditorGUILayout.PropertyField(propertyIsDebug, new GUIContent("Is Debug"));
            propertyScreenTemplates.arraySize = EditorGUILayout.IntField(new GUIContent("Screen Templates Size"), propertyScreenTemplates.arraySize);
            OnInspector_ScreenTemplatesArray();
            //
            serializedObject.ApplyModifiedProperties();
        }
        private void OnInspector_ScreenTemplatesArray()
        {
            GUILayout.Space(10);
            if (isShowScreenTemplates)
            {
                if (GUILayout.Button("Hide ScreenTemplates"))
                    isShowScreenTemplates = false;
                if (GUILayout.Button("Sort ScreenTemplates"))
                    fixResolutionCanvas.SortFactor();
                //
                int index = 0;
                foreach (SerializedProperty propertyScreenTemplate in propertyScreenTemplates)
                {
                    GUILayout.Space(5);
                    OnInspector_ScreenTemplate("ScreenTemplate " + index, propertyScreenTemplate);
                    index++;
                }
            }
            else
            {
                if (GUILayout.Button("Show ScreenTemplates"))
                    isShowScreenTemplates = true;
            }
        }
        private void OnInspector_ScreenTemplate(string title, SerializedProperty propertyScreenTemplate)
        {
            GUILayout.BeginVertical(title, "window");
            //
            SerializedProperty propertyScreenWidth = propertyScreenTemplate.FindPropertyRelative("screenWidth");
            SerializedProperty propertyScreenHeight = propertyScreenTemplate.FindPropertyRelative("screenHeight");
            SerializedProperty propertyCanvasScalerMatch = propertyScreenTemplate.FindPropertyRelative("canvasScalerMatch");
            //
            EditorGUILayout.PropertyField(propertyScreenWidth, new GUIContent("Width"));
            EditorGUILayout.PropertyField(propertyScreenHeight, new GUIContent("Height"));
            EditorGUILayout.PropertyField(propertyCanvasScalerMatch, new GUIContent("CanvasScaler Match"));
            //
            GUILayout.EndVertical();
        }
        #endregion UnityEvent		
    }
}
