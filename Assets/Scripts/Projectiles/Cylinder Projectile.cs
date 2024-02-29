using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderProjectile : projectile
{
    private float radius;
    private float height;
    // Start is called before the first frame update
    void Start()
    {

    }

    public CylinderProjectile(string material, float FrictionalCoefficient, float Restitution, float r, float h) : base(material, FrictionalCoefficient, Restitution)
    {
        this.materialName = material;
        density = materials[materialName];
        frictionalCoefficient = FrictionalCoefficient;
        restution = Restitution;
        radius = Mathf.Min(Mathf.Max(0.05f, r), 0.5f);
        height = Mathf.Min(Mathf.Max(0.05f, h), 1.0f);
        CalculateVolume();
        CalculateMass();
    }
    public float CalculateVolume()
    {
        //volume formula for Cylinder: 
        volume = Mathf.PI * height * radius * radius;
        return volume;
    }

    public Vector3 GetSize()
    {
        return new Vector3(radius * 2, (height / 2), radius * 2);
    }
}
