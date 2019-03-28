using HoloToolkit.Unity;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Receivers;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIReceiver : InteractionReceiver
{
    // Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

    public GameObject textObjectState;
    private TextMesh txt;
    private GameObject grupo;
    private bool active;
    GameObject canvasGO;
    GameObject titleGO;
    GameObject descriptionGO;
    Canvas canvas;
    VideoPlayer video;
    public Text text;
    public Text text2;
    private TargetCollection listaTargets;

    void Start()
    {
        //
        //video = GameObject.Find("MovieScreen").GetComponent<VideoPlayer>();
        video = transform.parent.Find("MovieScreen").GetComponent<VideoPlayer>();
        txt = textObjectState.GetComponentInChildren<TextMesh>();
        grupo = GameObject.Find("grupo");
        active = false;
        canvasGO = GameObject.Find("TextContent");
        canvas = canvasGO.GetComponent<Canvas>();
        // Create the Text GameObject.
        titleGO = GameObject.Find("Title");
        descriptionGO = GameObject.Find("Description");
        StartCoroutine(prepareVideo());
        video.playOnAwake = false;
        //video.Prepare();
        StartCoroutine(prepareVideo());
        listaTargets = new TargetCollection();
        DataTarget novint = new DataTarget();
        novint.targetName = "ImageTargetNovint";
        novint.titulo = "Novint Falcon (2007)";
        novint.historia = "El Novint Falcon es un tipo de mando de juego completamente nuevo." +
            " Al sustituir el ratón o el joystick, el Falcon es, en esencia," +
            " un pequeño robot que le permite experimentar un verdadero toque virtual," +
            " a diferencia de cualquier otro controlador de la historia.El Novint Falcon le permite controlar un juego en tres dimensiones," +
            " y también le permite sentir la retroalimentación de fuerza tridimensional de alta fidelidad. " +
            "El controlador Falcon se mueve a derecha e izquierda, hacia delante y hacia atrás, como un ratón, " +
            "pero también hacia arriba y hacia abajo.Cuando usted sostiene el Grip desmontable del Falcon y mueve " +
            "el cursor para interactuar con un objeto, entorno o personaje virtual, los motores del dispositivo se " +
            "encienden y se actualizan aproximadamente 1000 veces por segundo, lo que le permite sentir la textura, " +
            "la forma, el peso, la dimensión y la dinámica.El Falcon te permite controlar e interactuar con los juegos" +
            " de una manera más realista, lo que te permite desarrollar una verdadera habilidad física y memoria muscular, " +
            "añadiendo una nueva dimensión a los juegos. Traducción realizada con el traductor www.DeepL.com/Translator";

        novint.tesis = "No encontrado.";
        listaTargets.addTarget(novint);
        DataTarget shuterGlasses = new DataTarget();
        shuterGlasses.targetName = "ImageTargetAsus";
        shuterGlasses.titulo = "3D Shutter Glasses";
        shuterGlasses.historia = "Un sistema activo de obturador 3D es una técnica de visualización de imágenes en 3D estereoscópico." +
            " Funciona presentando solamente la imagen destinada al ojo izquierdo mientras que bloquea la vista del ojo derecho, " +
            "luego presentando la imagen del ojo derecho mientras bloquea el ojo izquierdo, y repitiendo esto tan rápidamente que " +
            "las interrupciones no interfieren con la fusión percibida de las dos imágenes en una sola imagen 3D." +
            "Los sistemas modernos de obturador activo 3D utilizan generalmente gafas de obturador de cristal líquido " +
            "(también llamadas \"gafas de obturador activo\"). El vidrio de cada ojo contiene una capa de cristal líquido" +
            " que tiene la propiedad de volverse opaco cuando se aplica el voltaje, siendo por lo demás transparente. " +
            "Las gafas están controladas por una señal de tiempo que permite que las gafas bloqueen alternativamente un ojo y " +
            "luego el otro, en sincronización con la frecuencia de refresco de la pantalla.La sincronización de tiempo con el equipo" +
            " de video puede lograrse a través de una señal alámbrica o de forma inalámbrica, ya sea por medio de un" +
            " transmisor de infrarrojos o de radiofrecuencia(por ejemplo, Bluetooth).";
        shuterGlasses.tesis = "No encontrado.";
        listaTargets.addTarget(shuterGlasses);
        Debug.Log(listaTargets.SaveToString());
    }

    protected override void FocusEnter(GameObject obj, PointerSpecificEventData eventData)
    {
        Debug.Log(obj.name + " : FocusEnter");
        txt.text = obj.name + " : FocusEnter";
    }

    protected override void FocusExit(GameObject obj, PointerSpecificEventData eventData)
    {
        Debug.Log(obj.name + " : FocusExit");
        txt.text = obj.name + " : FocusExit";
    }

    protected override void InputDown(GameObject obj, InputEventData eventData)
    {
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

            case "PlayButton":
                
                if (video.isPlaying)
                {
                    video.Pause();
                }
                else
                {
                    if (video.isPrepared)
                    {
                        video.Play();
                    }
                    else
                    {
                        Debug.Log("Video no preparado");
                    }
                }

                break;

            default:
                GameObject parent = obj.transform.root.gameObject;

                if (obj.name == "Historia" && listaTargets.buscarTarget(parent.name) != null)
                {
                    Debug.Log(obj.name + "Pressed");
                    GameObject titulo = obj.transform.root.Find("Contenido/Panel/Panel1/TextContent/Title").gameObject;
                    GameObject descripcion = obj.transform.root.Find("Contenido/Panel/Panel1/TextContent/Description").gameObject;
                    //titulo.GetComponent<Text>().text = listaTargets.buscarTarget(parent.name).titulo;
                    titulo.GetComponent<Text>().text = "Historia";
                    descripcion.GetComponent<Text>().text = listaTargets.buscarTarget(parent.name).historia;
                }
                else if (obj.name == "Tesis" && listaTargets.buscarTarget(parent.name) != null)
                {
                    Debug.Log(obj.name + "Pressed");
                    GameObject titulo = obj.transform.root.Find("Contenido/Panel/Panel1/TextContent/Title").gameObject;
                    GameObject descripcion = obj.transform.root.Find("Contenido/Panel/Panel1/TextContent/Description").gameObject;
                    //titulo.GetComponent<Text>().text = listaTargets.buscarTarget(parent.name).tituloTesis;
                    titulo.GetComponent<Text>().text = "Tesis";
                    descripcion.GetComponent<Text>().text = listaTargets.buscarTarget(parent.name).tesis;
                }
                else if (obj.name == "Demos" && listaTargets.buscarTarget(parent.name) != null)
                {
                    Debug.Log(obj.name + "Pressed");
                    GameObject titulo = obj.transform.root.Find("Contenido/Panel/Panel1/TextContent/Title").gameObject;
                    GameObject descripcion = obj.transform.root.Find("Contenido/Panel/Panel1/TextContent/Description").gameObject;
                    //titulo.GetComponent<Text>().text = listaTargets.buscarTarget(parent.name).tituloDemos;
                    titulo.GetComponent<Text>().text = "Demos";
                    descripcion.GetComponent<Text>().text = listaTargets.buscarTarget(parent.name).demos;
                }
                else
                {
                    GameObject titulo = obj.transform.root.Find("Contenido/Panel/Panel1/TextContent/Title").gameObject;
                    GameObject descripcion = obj.transform.root.Find("Contenido/Panel/Panel1/TextContent/Description").gameObject;
                    titulo.GetComponent<Text>().text = obj.name + "de : " + obj.transform.root.name;
                    descripcion.GetComponent<Text>().text = "Descripción de: " + obj.transform.root.name;
                }
                /*
                if (obj.name == "Historia" || obj.name == "Demos" || obj.name == "Tesis")
                {
                    Debug.Log(obj.name + "Pressed");
                    GameObject titulo = obj.transform.root.Find("Contenido/Panel/TextContent/Title").gameObject;
                    GameObject descripcion = obj.transform.root.Find("Contenido/Panel/TextContent/Description").gameObject;
                    titulo.GetComponent<Text>().text = obj.name + "de : " + obj.transform.root.name;
                    descripcion.GetComponent<Text>().text = "Descripción de: " + obj.transform.root.name;
                } */
                break;
        }

    }

    IEnumerator<int> prepareVideo()
    {
        video.Prepare();

        //Wait until video is prepared
        while (!video.isPrepared)
        {
            Debug.Log("Preparing Video");
            yield return 1;
        }
    }

    protected override void InputUp(GameObject obj, InputEventData eventData)
    {
        Debug.Log(obj.name + " : InputUp");
        txt.text = obj.name + " : InputUp";
    }
}
