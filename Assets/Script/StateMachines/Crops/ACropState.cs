using UnityEngine;

namespace Assets.Script.StateMachines.Crops
{
    public abstract class ACropState
    {
        internal FarmControl control;
        internal GameObject newObject;

        public ACropState(FarmControl control)
        {
            this.control = control;
        }

        public abstract ACropState Execute(GameObject[] children);
    }
}
