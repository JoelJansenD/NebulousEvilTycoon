using UnityEngine;

namespace Assets.Script.StateMachines.Crops
{
    public class YoungCropState : ACropState
    {
        public YoungCropState(FarmControl control) : base(control) { }

        public override ACropState Execute(GameObject[] children)
        {
            for (int i = 0; i < children.Length; i++)
            {
                children[i].GetComponent<MeshFilter>().sharedMesh = newObject.GetComponent<MeshFilter>().sharedMesh;
            }

            MatureCropState newState = new MatureCropState(control);
            newState.newObject = newObject;
            return newState;
        }
    }
}
