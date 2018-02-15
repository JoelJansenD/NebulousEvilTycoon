using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class HarvesterControl : MonoBehaviour {
    private NavMeshAgent agent;
    private GameObject cutter;
    private Transform target;
    private int targetIndex = 0;
    private bool moving = false;

    public Transform[] Targets;
    public Transform[] Wheels;

    public void HarvestCrops()
    {
        targetIndex = 0;
        agent.SetDestination(target.position + target.GetComponent<BoxCollider>().center);
        moving = true;
        StartCoroutine(RotateWheels());
    }

    private void Start()
    {
        target = Targets[targetIndex];
        agent = GetComponent<NavMeshAgent>();        
        cutter = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider crop)
    {
        agent.SetDestination(transform.position);
        StartCoroutine(RotateCutter(crop.gameObject));
        moving = false;
    }

    private IEnumerator RotateCutter(GameObject crop)
    {
        float elapsed = 0.0f;
        while (elapsed < 0.1f)
        {
            cutter.transform.Rotate(new Vector3(1000.0f * Time.deltaTime, 0, 0));
            elapsed += Time.deltaTime;
            yield return null;
        }

        crop.SetActive(false);
        targetIndex++;
        if(targetIndex < Targets.Length)
        {
            moving = true;
            StartCoroutine(RotateWheels());

            Debug.Log("Test");
            target = Targets[targetIndex];

            agent.SetDestination(target.position + target.GetComponent<BoxCollider>().center);
        }
    }

    private IEnumerator RotateWheels()
    {
        while (moving)
        {
            foreach(Transform wheel in Wheels)
            {
                wheel.Rotate(new Vector3(1000.0f * Time.deltaTime, 0, 0));
            }
            yield return null;
        }
    }
}
