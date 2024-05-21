using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    [SerializeField]
    private string name;
    [SerializeField]
    private AudioClip clip;

    public string Name { get { return name; } }
    public AudioClip Clip { get { return clip; } }
}
