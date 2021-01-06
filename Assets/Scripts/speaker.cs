using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class speaker : MonoBehaviour
{

    public GameObject tavuk;
    public GameObject hoparlör;

    public int angle;

    void Start()
    {
   

    }

    /*void Update()
    {   
            if(Input.GetMouseButton(0))
            {

                if (this.tavuk.transform.position.y < 6.1f && this.tavuk.transform.position.y > -6.2f && this.tavuk.transform.position.x < 3.0f && this.tavuk.transform.position.x > -3.0f)
                {
                    /*Vector3 mesafe = ((hoparlör.transform.forward * 4.0f) / Vector3.Distance(tavuk.transform.position, hoparlör.transform.position));
                    Debug.Log(mesafe);
                    tavuk.transform.position += ((hoparlör.transform.forward * 4.0f) / Vector3.Distance(tavuk.transform.position, hoparlör.transform.position));*/
    //tavuk.transform.position +=  hoparlör.transform.forward * /*new Vector3(-1.0f, 0f, 0f) */ Time.deltaTime * 5; 

    //tavuk.transform.position = this.tavuk.transform.position;
    /*              
                      this.tavuk.transform.position += ((hoparlör.transform.forward ) / Vector3.Distance(this.tavuk.transform.position, hoparlör.transform.position) * Time.deltaTime * 2);
                  }

                  else
                  {
                      Application.LoadLevel("Failed");
                  }
              }
     }*/

    void Update()
    {
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
                        tavuk.transform.position += (hoparlör.transform.forward) / Vector3.Distance(10*(this.tavuk.transform.position), (hoparlör.transform.position)*10) * Time.deltaTime * 100;
                        
                        if(hoparlör.transform.rotation.x ==  0)
                        {
                            tavuk.transform.eulerAngles = new Vector3(180, 90, -90);
                        }
                            
                        else
                            tavuk.transform.eulerAngles = new Vector3(hoparlör.transform.eulerAngles.x, 90, -90);
                    }

                    else
                    {
                        SceneManager.LoadScene("Failed");
                       
                    }


                }
            }
        }
    }

    private void OnCollisionEnter(Collision obj)
    {
        //Debug.Log("hoparlör carpisma gerceklesti..");
        SceneManager.LoadScene("Failed");
        
    }

    /*public void pointerDown()
    {
        Debug.Log("dsdsda");
    }*/
}

    

    /*private void OnMouseDown()
   {

        Vector3 mesafe = ((hoparlör.transform.forward * 4.0f) / Vector3.Distance(tavuk.transform.position, hoparlör.transform.position));
        Debug.Log(mesafe);

        tavuk.transform.position += ((hoparlör.transform.forward * 4.0f) / Vector3.Distance(tavuk.transform.position, hoparlör.transform.position));

        Vector3 kontrol = this.tavuk.transform.position + mesafe;



        /*while (this.tavuk.transform.position != kontrol)
        {
            tavuk.transform.localPosition += mesafe * Time.deltaTime * 0.1f;

    } */



