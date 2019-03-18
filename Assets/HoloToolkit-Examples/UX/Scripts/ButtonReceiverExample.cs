// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Unity;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Receivers;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;

    public class ButtonReceiverExample : InteractionReceiver
    {
        public GameObject textObjectState;
        private TextMesh txt;
        private GameObject grupo;
        private bool active;
        GameObject canvasGO;
        GameObject titleGO;
        GameObject descriptionGO;
        Canvas canvas;
        public Text text;
        public Text text2;

        void Start()
        {
            txt = textObjectState.GetComponentInChildren<TextMesh>();
            grupo = GameObject.Find("grupo");
            active = false;
            canvasGO = GameObject.Find("TextContent");
            canvas = canvasGO.GetComponent<Canvas>();
            // Create the Text GameObject.
            titleGO = GameObject.Find("Title");
            descriptionGO = GameObject.Find("Description");
        }

        protected override void FocusEnter(GameObject obj, PointerSpecificEventData eventData) {
            Debug.Log(obj.name + " : FocusEnter");
            txt.text = obj.name + " : FocusEnter";
        }

        protected override void FocusExit(GameObject obj, PointerSpecificEventData eventData) {
            Debug.Log(obj.name + " : FocusExit");
            txt.text = obj.name + " : FocusExit";
        }

        protected override void InputDown(GameObject obj, InputEventData eventData) {
            Debug.Log(obj.name + " : InputDown");
            txt.text = obj.name + " : InputDown";

            switch (obj.name)
            {
                case "MainButton":
                    // Do something when balloon is pressed
                    if (active)
                    {
                        active = !active;
                        grupo.SetActive(active);
                        Debug.Log(active);
                    }
                    else
                    {
                        active = !active;
                        grupo.SetActive(active);
                        Debug.Log(active);
                    }
                    
                    break;

                case "Historia":
                    
                    //textGO.transform.parent = canvasGO.transform;
                    //textGO.AddComponent<Text>();

                    // Set Text component properties.
                    text = titleGO.GetComponent<Text>();
                    text.text = "Historia";

                    text2 = descriptionGO.GetComponent<Text>();
                    text2.text = "In 1995 Sandia National Laboratories, a United States government laboratory," +
                        " bought one of the world's first commercial 3D haptic devices, and began developing haptic" +
                        " software. Sandia did core haptic research and research on how to use the technology for" +
                        " scientific visualization. It was one of the first companies in the world focused purely" +
                        " on the software side of the field of haptics. Anderson led the project at Sandia until" +
                        " 2000 at which point he founded Novint. Novint acquired an exclusive license to the technology" +
                        " and began to commercialize it." +
                        "Novint's vision was that the technology could fundamentally change computing, " +
                        "adding one of our most basic human senses and experiences to computers." +
                        " Given this vision, Novint was originally focused on consumer applications, " +
                        "but quickly found itself in a situation where the dot com bubble was bursting" +
                        " and the markets were collapsing. Investments in 2001 were difficult to come by" +
                        " for an early stage company, so Novint focused its efforts on higher end professional applications.";

                    // Do something when coffee cup is pressed
                    break;

                case "Tesis":
                 
                    text = titleGO.GetComponent<Text>();
                    text.text = "Tesis";

                    text2 = descriptionGO.GetComponent<Text>();
                    text2.text = "Aqui va info sobre las tesis";
             

                    // Do something when coffee cup is pressed
                    break;

                case "Demos":

                    text = titleGO.GetComponent<Text>();
                    text.text = "Demos";

                    text2 = descriptionGO.GetComponent<Text>();
                    text2.text = "Aqui se muestran las demos";


                    // Do something when coffee cup is pressed
                    break;

                default:
                    break;
            }

        }

        protected override void InputUp(GameObject obj, InputEventData eventData) {
            Debug.Log(obj.name + " : InputUp");
            txt.text = obj.name + " : InputUp";
        }
    }
