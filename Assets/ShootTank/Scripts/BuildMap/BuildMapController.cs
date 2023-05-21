using ShootTank.Data.Map;
using ShootTank.GameController.LevelLoad;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeObjectMap
{
    None,
    Brick,
    Stone,
    Grass,
    LaneSpeed,
    Water
}
namespace ShootTank.BuildMap
{
    public class BuildMapController : MonoBehaviour
    {
        public static BuildMapController instance;
        [TabGroup("FirstGroup", "UI")] [SerializeField] List<Image> listImgFrameSelectBrick;
        [TabGroup("FirstGroup", "UI")] [SerializeField] List<Button> listBtnFrameSelectBrick;

        [TabGroup("SecondGroup", "UI")] [SerializeField] Image imgObjectMap;
        [TabGroup("SecondGroup", "UI")] [SerializeField] Button btnStartBuild;
        [TabGroup("SecondGroup", "UI")] [SerializeField] Button btnFinishBuild;
        [SerializeField] SpriteRenderer sprObjectMap;

        TypeObjectMap typeObjectMap;

        List<GameObject> list_GameObjects = new List<GameObject>();
        GameObject gameObjectSpawn;

        List<Sprite> tmp = new List<Sprite>(); // list sprite show in tool build
        List<Sprite> tmp_1 = new List<Sprite>(); // list sprite show in tank
        int indexTypeMapObj = 0;
        int indexObjMap = 0;

        void Awake()
        {
            if (instance == null)
                instance = this;
        }

        private void Start()
        {
            Debug.Log("Start");
            Init(false);
        }
        public void OnClickTypeObjectMap(int indexObject)
        {

            isFinishBuild = false;
            typeObjectMap = SetTypeObjectMap(indexObject);

            //active frame select
            listImgFrameSelectBrick[indexObjMap].gameObject.SetActive(true);

            if (indexObjMap > 0)
                listImgFrameSelectBrick[indexObjMap - 1].gameObject.SetActive(false);
            else
                listImgFrameSelectBrick[listImgFrameSelectBrick.Count - 1].gameObject.SetActive(false);
            if (indexObject == 5)
            {
                imgObjectMap.sprite = null;
                sprObjectMap.sprite = null;
                listBtnFrameSelectBrick[5].interactable = false;
                return;
            }
            listBtnFrameSelectBrick[5].interactable = true;


            tmp = SpriteTypeObjectMap.GetListSpriteMap(indexObject);
            tmp_1 = SpriteTypeObjectMap.GetListSpriteMapFollowTank(indexObject);
            list_GameObjects = SpriteTypeObjectMap.GetListGameObjectMap(indexObject);
            indexTypeMapObj = 0;
            imgObjectMap.sprite = tmp[indexTypeMapObj];
            sprObjectMap.sprite = tmp_1[indexTypeMapObj];
        }
        public void OnClickChangeType()
        {
            if (indexTypeMapObj >= tmp.Count - 1)
                indexTypeMapObj = 0;
            else
                indexTypeMapObj++;
            imgObjectMap.sprite = tmp[indexTypeMapObj];
            sprObjectMap.sprite = tmp_1[indexTypeMapObj];
            gameObjectSpawn = list_GameObjects[indexTypeMapObj];
        }

        TypeObjectMap SetTypeObjectMap(int indexObj)
        {
            switch (indexObj)
            {
                case 0: return TypeObjectMap.Brick;
                case 1: return TypeObjectMap.Stone;
                case 2: return TypeObjectMap.Grass;
                case 3: return TypeObjectMap.Water;
                case 4: return TypeObjectMap.LaneSpeed;
                default: return TypeObjectMap.None;
            }
        }
        Vector3 pos;
        float sizeCam = 5;

        private void Update()
        {
            if (isFinishBuild)
                return;
            pos = LevelInfor.instance.tankManager.transform.localPosition;
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (pos.x > sizeCam * -1 && pos.x < sizeCam && pos.y > sizeCam * -1 && pos.y < sizeCam)
                {
                    string x = typeObjectMap.ToString();
                    //GameObject tmp = (GameObject)PrefabUtility.InstantiatePrefab(gameObjectSpawn, GameObject.Find(x).transform);
                    //tmp.transform.localPosition = sprObjectMap.transform.localPosition;
                }
            }
            //set sprite show in tank
            SetSpriteFollowTank(indexTypeMapObj);

            if (Input.GetKeyDown(KeyCode.C))
            {
                OnClickChangeType();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (indexObjMap >= listImgFrameSelectBrick.Count - 1)
                    indexObjMap = 0;
                else
                    indexObjMap++;
                OnClickTypeObjectMap(indexObjMap);
                indexTypeMapObj = -1;
                OnClickChangeType();
            }
        }
        // =============== DONE BUILD ================
        public bool isFinishBuild = false;
        public void OnClickFinishBuild()
        {
            isFinishBuild = true;
            Init(!isFinishBuild);
            //AssetDatabase.CreateAsset(, "Assets/yourmesh.asset");
            //AssetDatabase.SaveAssets();
            //LevelInfor.instance.gameObject
            //ES3.Save<int>("myKey", 123, Application.dataPath + "/Resources/myFile.bytes");
            //AssetDatabase.Refresh();
        }

        /// <summary>
        /// isBuild = true : Building
        /// </summary>
        /// <param name="isBuild"></param>
        public void Init(bool isBuild)
        {
                Debug.Log("isBuild: " + isBuild);
            if (isBuild)
            {
                LevelInfor.instance.tankManager.GetComponent<BoxCollider2D>().enabled = !isBuild;
                indexObjMap = 0;
                indexTypeMapObj = 0;
                OnClickTypeObjectMap(0);
                OnClickChangeType();
                listImgFrameSelectBrick[0].gameObject.SetActive(isBuild);
            }
            else
            {
               LevelInfor.instance.tankManager.GetComponent<BoxCollider2D>().enabled = !isBuild;
                foreach (Image i in listImgFrameSelectBrick)
                    i.gameObject.SetActive(isBuild);
            }
            isFinishBuild = !isBuild;
            btnStartBuild.interactable = !isBuild;
            btnFinishBuild.interactable = isBuild;
            foreach (Button i in listBtnFrameSelectBrick)
                i.interactable = isBuild;
            sprObjectMap.gameObject.SetActive(isBuild);
        }
        // set sprite fllow tank
        // set position object map follow tank
        void SetSpriteFollowTank(int indexSprite)
        {
          //  Vector3 pos = TankManager.instance.transform.localPosition;
            switch (indexSprite)
            {
                case 0:
                    sprObjectMap.transform.localPosition = new Vector3(pos.x - 0.1f, pos.y + 0.1f, 0);
                    break;
                case 1:
                    sprObjectMap.transform.localPosition = new Vector3(pos.x - 0.1f, pos.y, 0);
                    break;
                case 2:
                    sprObjectMap.transform.localPosition = new Vector3(pos.x, pos.y - 0.1f, 0);
                    break;
                case 3:
                    sprObjectMap.transform.localPosition = new Vector3(pos.x + 0.1f, pos.y, 0);
                    break;
                case 4:
                    sprObjectMap.transform.localPosition = new Vector3(pos.x, pos.y + 0.1f, 0);
                    break;
                case 5:
                    sprObjectMap.transform.localPosition = new Vector3(pos.x, pos.y, 0);
                    break;
            }
        }
    }
}