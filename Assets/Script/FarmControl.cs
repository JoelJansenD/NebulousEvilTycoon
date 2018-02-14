using Assets.Script.StateMachines.Crops;
using UnityEngine;

public class FarmControl : MonoBehaviour
{
    private ACropState cropState;

    public GameObject[] Crops;
    public GameObject Farmland;
    public GameObject Seedling;
    public GameObject YoungCrop;
    public GameObject MatureCrop;
    public GameObject Harvester;
    public FarmState GrowthStage;

    private void Start()
    {
        if(GrowthStage == FarmState.None)
        {
            cropState = new NoCropState(this);
            cropState.newObject = Seedling;
        }
        else if(GrowthStage == FarmState.Growing)
        {
            cropState = new GrowingCropState(this);
            cropState.newObject = YoungCrop;
        }
        else if(GrowthStage == FarmState.Young)
        {
            cropState = new YoungCropState(this);
            cropState.newObject = MatureCrop;
        }
        else
        {
            cropState = new MatureCropState(this);
            cropState.newObject = MatureCrop;
        }
    }

    // Update is called once per frame
    private void Update () {
        //TODO: Base on in-game time
        if (Input.GetButtonDown("TestCorn"))
        {
            cropState = cropState.Execute(Crops);
        }
	}

    public enum FarmState
    {
        None,
        Growing,
        Young,
        Mature
    }
}
