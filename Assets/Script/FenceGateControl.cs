
using System.Collections;
using UnityEngine;

public class FenceGateControl : MonoBehaviour {
    private GameObject leftDoor;
    private GameObject rightDoor;

    private Vector3 leftClosed;
    private Vector3 rightClosed;
    private Vector3 leftOpen;
    private Vector3 rightOpen;
    private float bounds = 2.0f;

    public float LeftGatePosition;
    public float RightGatePosition;
    public float Speed;

    private void Start()
    {
        leftDoor = transform.GetChild(0).gameObject;
        rightDoor = transform.GetChild(1).gameObject;

        leftClosed = leftDoor.transform.localEulerAngles;
        leftClosed.y = 0;

        leftOpen = leftDoor.transform.localEulerAngles;
        leftOpen.y = LeftGatePosition;

        rightClosed = rightDoor.transform.localEulerAngles;
        rightClosed.y = 0;

        rightOpen = rightDoor.transform.localEulerAngles;
        rightOpen.y = 360 - RightGatePosition; //Because the door opens mirrored to the left door, subtract from 360 to calculate relative rotations
    }

    private void Update()
    {
        //TODO: Base on in-game events
        if (Input.GetButtonDown("TestCorn"))
        {
            StartCoroutine("OpenLeftDoor");
            StartCoroutine("OpenRightDoor");
        }
        else if(Input.anyKeyDown)
        {
            StartCoroutine("CloseLeftDoor");
            StartCoroutine("CloseRightDoor");
        }
    }

    private IEnumerator OpenLeftDoor()
    {
        float distance = Mathf.Abs(Vector3.Distance(leftDoor.transform.localEulerAngles, leftOpen));
        while (distance > bounds)
        {
            leftDoor.transform.Rotate(0, Speed * Time.deltaTime, 0);
            distance = Mathf.Abs(Vector3.Distance(leftDoor.transform.localEulerAngles, leftOpen));
            yield return null;
        }
    }

    private IEnumerator OpenRightDoor()
    {
        float distance = Mathf.Abs(Vector3.Distance(rightDoor.transform.localEulerAngles, rightOpen));
        while (distance > bounds)
        {
            rightDoor.transform.Rotate(0, -Speed * Time.deltaTime, 0);
            distance = Mathf.Abs(Vector3.Distance(rightDoor.transform.localEulerAngles, rightOpen));
            yield return null;
        }
    }

    private IEnumerator CloseLeftDoor()
    {
        float distance = Mathf.Abs(Vector3.Distance(leftDoor.transform.localEulerAngles, leftClosed));
        while (distance > bounds)
        {
            leftDoor.transform.Rotate(0, -Speed * Time.deltaTime, 0);
            distance = Mathf.Abs(Vector3.Distance(leftDoor.transform.localEulerAngles, leftClosed));
            yield return null;
        }
    }

    private IEnumerator CloseRightDoor()
    {
        float distance = Mathf.Abs(Vector3.Distance(rightDoor.transform.localEulerAngles, rightClosed));
        while (distance > bounds)
        {
            rightDoor.transform.Rotate(0, Speed * Time.deltaTime, 0);
            distance = Mathf.Abs(Vector3.Distance(rightDoor.transform.localEulerAngles, rightClosed));
            yield return null;
        }
    }
}
