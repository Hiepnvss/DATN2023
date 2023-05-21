using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KTool.FixResolution
{
    [RequireComponent(typeof(CanvasScaler))]
    public class FixResolutionCanvas : MonoBehaviour
    {
        #region Properties
        [SerializeField]
        private bool isDebug = true;
        [SerializeField]
        private ScreenTemplate[] screenTemplates = null;

        private CanvasScaler canvasScaler;
        private Vector2 currentScreenSize = Vector2.zero;
        #endregion Properties

        #region Unity Event
        private void Awake()
        {
            Init();
        }

        private void Start()
        {

        }

        private void Update()
        {
            Update_ScreenSize();
        }
        #endregion Unity Event

        private void Init()
        {
            canvasScaler = GetComponent<CanvasScaler>();
            currentScreenSize = GetScreenSize();
            SortFactor();
            SetWindowAspectRatio();
        }

        private void Update_ScreenSize()
        {
            if (screenTemplates == null || screenTemplates.Length <= 0)
                return;
            Vector2 newScreenSize = GetScreenSize();
            if (currentScreenSize.x != newScreenSize.x || currentScreenSize.y != newScreenSize.y)
            {
                currentScreenSize = newScreenSize;
                SetWindowAspectRatio();
            }
        }
        private void SetResolutionFactor(ScreenTemplate factor)
        {
            canvasScaler.matchWidthOrHeight = factor.MatchWidthOrHeight;
        }
        private void SetResolutionFactor_Default()
        {
            Camera cam = Camera.main;
            ScreenTemplate factor = new ScreenTemplate(cam.pixelWidth, cam.pixelHeight, canvasScaler.matchWidthOrHeight);
            //
            SetResolutionFactor(factor);
        }
        public void SetWindowAspectRatio()
        {
            int indexSelect = GetFactorIndex();
            if (indexSelect == -1)
                SetResolutionFactor_Default();
            else
                SetResolutionFactor(screenTemplates[indexSelect]);
        }
        private int GetFactorIndex()
        {
            if (screenTemplates == null || screenTemplates.Length == 0)
                return -1;
            //
            int index = -1;
            float screenAspect = currentScreenSize.x / currentScreenSize.y;
            for (int i = 0; i < screenTemplates.Length; i++)
            {
                if (screenAspect == screenTemplates[i].ScreenAspect)
                {
                    index = i;
                    break;
                }
                else if (screenAspect < screenTemplates[i].ScreenAspect)
                {
                    if (i == 0)
                    {
                        index = i;
                    }
                    else
                    {
                        if (screenAspect - screenTemplates[i - 1].ScreenAspect < screenTemplates[i].ScreenAspect - screenAspect)
                            index = i - 1;
                        else
                            index = i;
                    }
                    break;
                }
            }
            //
            return index;
        }
        private Vector2 GetScreenSize()
        {
            Camera cam = Camera.main;
            if (cam != null)
                return new Vector2(cam.pixelWidth, cam.pixelHeight);
            return new Vector2(Screen.width, Screen.height);
        }
        public void SortFactor()
        {
            for (int i = 0; i < screenTemplates.Length - 1; i++)
                for (int j = 0; j < screenTemplates.Length - 1; j++)
                {
                    if (screenTemplates[j].ScreenAspect > screenTemplates[j + 1].ScreenAspect)
                    {
                        ScreenTemplate tmp = screenTemplates[j];
                        screenTemplates[j] = screenTemplates[j + 1];
                        screenTemplates[j + 1] = tmp;
                    }
                }
        }
    }
}
