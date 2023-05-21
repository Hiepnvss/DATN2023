//using ShootTank.Data.Map;
//using Sirenix.OdinInspector;
//using Sirenix.OdinInspector.Editor;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//public enum TypeObjectMap
//{
//    Brick,
//    Stone,
//    Grass,
//    Water,
//    LaneSpeed
//}
//namespace ShootTank.Editor
//{
//    public class MyCustomEditor : OdinEditor
//    {
//        void OnSceneGUI()
//        {
//            Event e = Event.current;
//            switch (e.type)
//            {
//                case EventType.KeyDown:
//                    Debug.Log("keydown");
//                    break;
//            }
//        }
//    }
//    public class EditorBuildMap : OdinEditorWindow
//    {
//        [MenuItem("Tools/BuildMap")]
//        private static void OpenWindow()
//        {
//            GetWindow<EditorBuildMap>().Show();
//        }

//        [EnumToggleButtons, BoxGroup("TypeObjectMap")]
//        public TypeObjectMap typeObjectMap;

//        int indexTypeMapObj = 0;
//        private void OnValidate()
//        {
//            List<Sprite> tmp = new List<Sprite>();
//            switch (typeObjectMap)
//            {
//                case TypeObjectMap.Brick:
//                    tmp = SpriteTypeObjectMap.GetListSpriteMap(0);
//                    break;
//                case TypeObjectMap.Stone:
//                    tmp = SpriteTypeObjectMap.GetListSpriteMap(1);
//                    break;
//                case TypeObjectMap.Grass:
//                    tmp = SpriteTypeObjectMap.GetListSpriteMap(2);
//                    break;
//                case TypeObjectMap.Water:
//                    tmp = SpriteTypeObjectMap.GetListSpriteMap(3);
//                    break;
//                case TypeObjectMap.LaneSpeed:
//                    tmp = SpriteTypeObjectMap.GetListSpriteMap(4);
//                    break;
//            }
//            spriteObjectMap = tmp[0];
//            indexTypeMapObj = 0;
//        }

//        [LabelText("View")]

//        [HorizontalGroup("Split", Width = 500), HideLabel, PreviewField(150)]
//        public Sprite spriteObjectMap;

//        GameObject gameObjectSpawn;
//        List<GameObject> list_GameObjects = new List<GameObject>();

//        [HorizontalGroup("Split"), Button("ChangeType", ButtonSizes.Large)]
//        void ChangeType()
//        {
//            List<Sprite> tmp = new List<Sprite>();
//            switch (typeObjectMap)
//            {
//                case TypeObjectMap.Brick:
//                    tmp = SpriteTypeObjectMap.GetListSpriteMap(0);
//                    list_GameObjects = SpriteTypeObjectMap.GetListGameObjectMap(0);
//                    break;
//                case TypeObjectMap.Stone:
//                    tmp = SpriteTypeObjectMap.GetListSpriteMap(1);
//                    list_GameObjects = SpriteTypeObjectMap.GetListGameObjectMap(1);
//                    break;
//                case TypeObjectMap.Grass:
//                    tmp = SpriteTypeObjectMap.GetListSpriteMap(2);
//                    list_GameObjects = SpriteTypeObjectMap.GetListGameObjectMap(2);
//                    break;
//                case TypeObjectMap.Water:
//                    tmp = SpriteTypeObjectMap.GetListSpriteMap(3);
//                    list_GameObjects = SpriteTypeObjectMap.GetListGameObjectMap(3);
//                    break;
//                case TypeObjectMap.LaneSpeed:
//                    tmp = SpriteTypeObjectMap.GetListSpriteMap(4);
//                    list_GameObjects = SpriteTypeObjectMap.GetListGameObjectMap(4);
//                    break;
//            }
//            if (indexTypeMapObj >= tmp.Count - 1)
//                indexTypeMapObj = 0;
//            else
//                indexTypeMapObj++;
//            spriteObjectMap = tmp[indexTypeMapObj];

//        }

//        [HorizontalGroup("Split"), Button("Spawn", ButtonSizes.Large)]
//        void Spawn()
//        {
//            gameObjectSpawn = list_GameObjects[indexTypeMapObj];
//            switch (typeObjectMap)
//            {
//                case TypeObjectMap.Brick:
//                    PrefabUtility.InstantiatePrefab(gameObjectSpawn, GameObject.Find("Brick").transform);
//                    break;
//                case TypeObjectMap.Stone:
//                    PrefabUtility.InstantiatePrefab(gameObjectSpawn, GameObject.Find("Stone").transform);
//                    break;
//                case TypeObjectMap.Grass:
//                    PrefabUtility.InstantiatePrefab(gameObjectSpawn, GameObject.Find("Grass").transform);
//                    break;
//                case TypeObjectMap.Water:
//                    PrefabUtility.InstantiatePrefab(gameObjectSpawn, GameObject.Find("Water").transform);
//                    break;
//                case TypeObjectMap.LaneSpeed:
//                    PrefabUtility.InstantiatePrefab(gameObjectSpawn, GameObject.Find("LaneSpeed").transform);
//                    break;
//            }
//        }
//        [Button("Close")]
//        public void CloseWindow()
//        {
//            Debug.Log("Close window");
//        }
//        private float range = 0.0f;
        
//    }

//}
