using ShootTank.Tank;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootTank.GameController.LevelLoad
{
    public class LevelLoader : MonoBehaviour
    {
        public static LevelLoader instance;

        [HideInInspector] public TankManager tankManager;
        public LevelInfor map = null;

        private void Awake()
        {
            if (instance == null)
                instance = this;

            LoadLevel();
        }

        public void SetTankManager(TankManager _obj = null)
        {
            if (_obj != null)
                tankManager = _obj;
        }
        void LoadLevel()
        {
            string path = "Map" + VariableSystem.LevelPlaying;
            map = Instantiate(Resources.Load<LevelInfor>(path), Vector3.zero, Quaternion.identity);
            map.transform.SetParent(transform);
        }
    }
}
