using UnityEngine;

namespace Assets.Script.StateMachines.Crops
{
    public class MatureCropState : ACropState
    {
        public MatureCropState(FarmControl control) : base(control) { }

        public override ACropState Execute(GameObject[] children)
        {
            control.Harvester.GetComponent<HarvesterControl>().HarvestCrops();

            NoCropState newState = new NoCropState(control);
            newState.newObject = control.Seedling;
            return newState;
        }
    }
}
