using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class CameraWizard : Editor
{
    Camera u;
    Transform i;
    void Start()
    {
        
        u = SceneView.currentDrawingSceneView.camera;
        i = u.GetComponent<Transform>();
        if(Input.GetKeyDown(KeyCode.Backspace))
        { 
            Debug.Log(i); 
        }
       }

    // Update is called once per frame
    void Update()
    {
        
    }
}
