using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public AnimatorOverrideController Char2;
    
    public void Char2Skin()
    {
        GetComponent<Animator>().runtimeAnimatorController = Char2 as RuntimeAnimatorController;
    }
    public AnimatorOverrideController Char1;

    public void Char1Skin()
    {
        GetComponent<Animator>().runtimeAnimatorController = Char1 as RuntimeAnimatorController;
    }
}
