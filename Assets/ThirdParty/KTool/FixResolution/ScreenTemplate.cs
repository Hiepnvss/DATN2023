using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KTool.FixResolution
{
    [Serializable]
    public struct ScreenTemplate
    {
        #region Properties
        private const string FORMAT_NAME = "Screen {0}/{1}";
        [SerializeField]
        [Min(0)]
        [Tooltip("Kich thuoc man hinh")]
        private float screenWidth,
            screenHeight;
        [SerializeField]
        [Range(0, 1)]
        [Tooltip("Uu tien scale theo chieu rong hay chieu cao")]
        private float canvasScalerMatch;

        public string Name => string.Format(FORMAT_NAME, screenWidth, screenHeight);
        public float ScreenWidth => screenWidth;
        public float ScreenHeight => screenHeight;
        public float ScreenAspect => screenWidth / screenHeight;
        public float MatchWidthOrHeight => canvasScalerMatch;
        #endregion Properties

        #region Construction
        public ScreenTemplate(float screenWidth, float screenHeight, float match)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.canvasScalerMatch = match;
        }
        #endregion Construction
    }
}
