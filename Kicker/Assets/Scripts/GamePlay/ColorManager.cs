using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager: MonoBehaviour
{
    public FootballerAppearance SettingsFootballer;
    public MeshRenderer meshFootballer;
    void Update()
    {
        meshFootballer.material = SettingsFootballer.mesh.material;   
    }
}
