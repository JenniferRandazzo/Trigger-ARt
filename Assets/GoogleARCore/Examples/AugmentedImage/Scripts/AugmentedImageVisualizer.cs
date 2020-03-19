//-----------------------------------------------------------------------
// <copyright file="AugmentedImageVisualizer.cs" company="Google">
//
// Copyright 2018 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.AugmentedImage
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;

    /// <summary>
    /// Uses 4 frame corner objects to visualize an AugmentedImage.
    /// </summary>
    public class AugmentedImageVisualizer : MonoBehaviour
    {
        /// <summary>
        /// The AugmentedImage to visualize.
        /// </summary>
        public AugmentedImage Image;

        /// <summary>
        /// A model for the lower left corner of the frame to place when an image is detected.
        /// </summary>
        public GameObject FrameLowerLeft;

        public GameObject FrameUpperRight;

        public Button ButtonProceed;

        public Button ButtonCensor;

        private bool ProceedState;

        private bool CensorState;

        //public Texture newPlaneTexture;

        //public Material newPlaneMaterial;


        //public GameObject FrameLowerRight;
        
        //public GameObject FrameUpperLeft;


        void Start()
        {
            ButtonProceed.onClick.AddListener(ProceedClicked);
            ButtonCensor.onClick.AddListener(CensorClicked);
            //newPlaneTexture = (Texture2D)Resources.Load("infographic");
        }

        void ProceedClicked()
        {
            ProceedState = true;
            HideButtons();
            FrameUpperRight.SetActive(false);

        }

        void CensorClicked()
        {
            CensorState = true;
            HideButtons();
            //FrameLowerLeft.GetComponent<Renderer>().material.mainTexture = newPlaneTexture;
            //FrameLowerLeft.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }

        void HideButtons()
        {
            ButtonProceed.gameObject.SetActive(false);
            ButtonCensor.gameObject.SetActive(false);
        }

        /// <summary>
        /// The Unity Update method.
        /// </summary>
        public void Update()
        {
            float width = Image.ExtentX;
            float height = Image.ExtentZ;

            if (Image == null || Image.TrackingState != TrackingState.Tracking || ProceedState)
            {
                FrameLowerLeft.SetActive(false);
                //FrameLowerRight.SetActive(false);
                //FrameUpperLeft.SetActive(false);
                FrameUpperRight.SetActive(false);
                return;
            }

            if (CensorState)
            {
                FrameLowerLeft.SetActive(false);
                FrameUpperRight.SetActive(true);
                FrameUpperRight.transform.localPosition = new Vector3(0, 0, 0);
                FrameUpperRight.transform.localScale = new Vector3(width, 1, height);

                /// supposed to change the texture of the plane here, but it doesn't work
                //FrameLowerLeft.GetComponent<Renderer>().material.mainTexture = newPlaneTexture;
            }

            FrameLowerLeft.transform.localPosition = new Vector3(0, 0, 0);
            FrameLowerLeft.transform.localScale = new Vector3(width, 1, height);
            //FrameLowerRight.transform.localPosition = new Vector3(0, 0, 0);
            //FrameLowerRight.transform.localScale = new Vector3(width, 1, height);

            //FrameLowerLeft.transform.localPosition =
            //(halfWidth * Vector3.left) + (halfHeight * Vector3.back);
            //FrameLowerRight.transform.localPosition =
            //    (halfWidth * Vector3.right) + (halfHeight * Vector3.back);
            //FrameUpperLeft.transform.localPosition =
            //    (halfWidth * Vector3.left) + (halfHeight * Vector3.forward);
            //FrameUpperRight.transform.localPosition =
            //    (halfWidth * Vector3.right) + (halfHeight * Vector3.forward);

            FrameLowerLeft.SetActive(true);
            //FrameUpperRight.SetActive(true);
            //FrameLowerRight.SetActive(true);
            //FrameUpperLeft.SetActive(true);

        }
    }
}
