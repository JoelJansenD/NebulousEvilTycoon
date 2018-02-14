using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.StateMachines.Crops
{
    public class NoCropState : ACropState
    {
        public NoCropState(FarmControl control) : base(control) { }

        public override ACropState Execute(GameObject[] children)
        {
            for (int i = 0; i < children.Length; i++)
            {
                children[i].GetComponent<MeshFilter>().sharedMesh = newObject.GetComponent<MeshFilter>().sharedMesh;
                children[i].SetActive(true);
            }

            GrowingCropState newState = new GrowingCropState(control);
            newState.newObject = control.YoungCrop;
            return newState;
        }
    }
}
