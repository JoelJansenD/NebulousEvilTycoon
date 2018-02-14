using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class HarvesterControl : MonoBehaviour {
    private NavMeshAgent agent;
    private GameObject cutter;
    private Transform target;
    private int targetIndex = 0;

    public Transform[] Targets;
    public int Speed;
    public int TurnSpeed;

    public void HarvestCrops()
    {
        agent.SetDestination(target.position + target.GetComponent<BoxCollider>().center);
    }

    private void Start()
    {
        target = Targets[targetIndex];
        agent = GetComponent<NavMeshAgent>();        
        cutter = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider crop)
    {
        Debug.Log("REEEEEEE!");
        agent.SetDestination(transform.position);
        StartCoroutine(RotateCutter(crop.gameObject));
        //agent.updatePosition = false;
        //agent.updateRotation = false;
        //agent.updateUpAxis = false;
    }

    private IEnumerator RotateCutter(GameObject crop)
    {
        float elapsed = 0.0f;
        while (elapsed < 2.0f)
        {
            cutter.transform.Rotate(new Vector3(1000.0f * Time.deltaTime, 0, 0));
            elapsed += Time.deltaTime;
            yield return null;
        }

        crop.SetActive(false);
        targetIndex++;
        if(targetIndex < Targets.Length)
        {
            target = Targets[targetIndex];
            agent.SetDestination(target.position + target.GetComponent<BoxCollider>().center);
        }
    }
}
