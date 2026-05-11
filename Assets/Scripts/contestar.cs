using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class contestar : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public string yarnNode = "Telefono";

    public GameObject phoneObject;
    public float interactDistance = 3f;
    public float ringDelay = 5f;

    private bool canAnswer = false;
    private bool answered = false;

    void Start()
    {
        StartCoroutine(StartPhoneRing());
        phoneObject.SetActive(true);
    }

    IEnumerator StartPhoneRing()
    {
        yield return new WaitForSeconds(ringDelay);
        canAnswer = true;
        Debug.Log("RING RIIIIING");
    }

    void Update()
    {
        if (!canAnswer || answered) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                Debug.Log("HIT: " + hit.transform.name);

                if (hit.transform.GetComponentInParent<contestar>() != null)
                {
                    AnswerPhone();
                }
            }
        }
    }

    void AnswerPhone()
    {
        answered = true;

        Debug.Log("HAS CONTESTADO");

        phoneObject.SetActive(false);

        dialogueRunner.StartDialogue(yarnNode);
    }
}