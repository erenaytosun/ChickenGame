using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class speaker : MonoBehaviour
{

    public GameObject tavuk;
    public GameObject hoparlör;

    [SerializeField] private GameObject timeBar;
    TimeBarScript timeBarScript;

    speaker speakerControl;

    private void Start()
    {
        timeBarScript = timeBar.GetComponent<TimeBarScript>();
        speakerControl = gameObject.GetComponent<speaker>();
    }
    void Update()
    {
        if (GameManager.isGameStarted == false || GameManager.isGameEnded == true)
            return;

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == this.hoparlör.gameObject)
                {
                    if (this.tavuk.transform.position.y < 9.3f && this.tavuk.transform.position.y > -9.3f && this.tavuk.transform.position.x < 4.5f && this.tavuk.transform.position.x > -4.5f)
                    {
                        tavuk.transform.position += (hoparlör.transform.forward) / Vector3.Distance(10 * (this.tavuk.transform.position), (hoparlör.transform.position) * 10) * Time.deltaTime * 150;

                        if (hoparlör.transform.rotation.x == 0)
                        {
                            tavuk.transform.eulerAngles = new Vector3(180, 90, -90);
                        }

                        else
                            tavuk.transform.eulerAngles = new Vector3(hoparlör.transform.eulerAngles.x, 90, -90);
                    }

                    else
                    {
                        GameManager.instance.falseIcon.SetActive(true);
                        timeBarScript.enabled = false;
                        GameManager.instance.Invoke("Failed", 1.5f);

                    }


                }
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "chicken")
        {

            GameManager.instance.falseIcon.SetActive(true);
            timeBarScript.enabled = false;
          

            GameManager.isGameEnded = true;
            GameManager.instance.Invoke("Failed", 1.5f);
        }
    }
}



