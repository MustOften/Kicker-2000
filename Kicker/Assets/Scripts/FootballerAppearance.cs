using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballerAppearance : MonoBehaviour
{
    public Material[] Materials;
    public MeshRenderer mesh;
    public int CurrentIndexColor;


    // Start is called before the first frame update
    void Start()
    {
        mesh.material = Materials[CurrentIndexColor];
    }

    public void NextColor()
    {
        CurrentIndexColor++;
        if (CurrentIndexColor == Materials.Length)
            CurrentIndexColor = 0;
        mesh.material = Materials[CurrentIndexColor];       
    }

    public void PreviousColor()
    {
        CurrentIndexColor--;
        if (CurrentIndexColor < 0)
            CurrentIndexColor = Materials.Length - 1;
        mesh.material = Materials[CurrentIndexColor];
    }
}
