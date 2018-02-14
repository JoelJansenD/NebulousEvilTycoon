using UnityEngine;

namespace Assets.Script.StateMachines.Crops
{
    public class GrowingCropState : ACropState
    {
        public GrowingCropState(FarmControl control) : base(control) { }

        public override ACropState Execute(GameObject[] children)
        {
            for(int i = 0; i < children.Length; i++)
            {
                children[i].GetComponent<MeshFilter>().sharedMesh = newObject.GetComponent<MeshFilter>().sharedMesh;
            }

            YoungCropState newState = new YoungCropState(control);
            newState.newObject = control.MatureCrop;
            return newState;
        }
    }
}
