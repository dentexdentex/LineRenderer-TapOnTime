using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public LineRenderer lr;
    public GameObject GO;
    public RaycastHit hit;
    public static int a, b;
    void Start()
    {

    }
    void Update()
    {/*
        // Debug.DrawLine(transform.position+Vector3.back, transform.position + Vector3.forward, Color.black);
        Debug.DrawLine(transform.position, transform.position + Vector3.forward, Color.black);
        Ray ray = new Ray(transform.position, transform.position + Vector3.forward);
        if (Physics.Raycast(ray, 1f))
        {
            Debug.Log("çarptı");
            if (Input.GetMouseButtonDown(0))
            {

                changePos();
            }

        }
        else
        {
            //  Debug.Log("çarpmadı");


        }
    */
    }
    /*
     if (GetComponent<Slerp>().lastPosCount > a&& GetComponent<Slerp>().lastPosCount <b) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                changePos();
            }
        }

     */

    /*Debug.DrawLine(transform.position, hit.point, Color.black);
          Ray ray = new Ray(transform.position, transform.right);
          if (Physics.Raycast(ray,1f))
          {
              Debug.Log("çarptı");
              if (Input.GetMouseButtonDown(0))
              {
                  changePos();
              }

          }
          else
          {
            //  Debug.Log("çarpmadı");
          }*/

    /*
    private void OnTriggerStay(Collider other)//ontriggerstay  --raycast
    {
        if(Input.GetMouseButtonDown(0))
        {
            changePos();
        }
    }
    */

    public void changePos()
    {
        GO = GameObject.Find("parent creater(Clone)");
        int randomPos = Random.Range(0, lr.positionCount - 151);
        a = randomPos;
        //print(lr.positionCount);
        
        for (int i = 0; i < GO.transform.childCount; i++)
        {
            print(GO.transform.childCount);
            //randomPos=başlangıçtakş ;
            GO.transform.GetChild(i).transform.position = lr.GetPosition(randomPos);
            // newChildObj.transform.parent = newParentObj.transform;
            randomPos = randomPos + 1;
        }
        print(GO.transform.childCount);
        b = randomPos;
        GO.GetComponent<LineRenderer>().positionCount = GO.transform.childCount;
        for (int y = 0; y < GO.transform.childCount; y++)
        {
            GO.GetComponent<LineRenderer>()
                .SetPosition(y, GO.transform.GetChild(y).transform.position);
        }
    }

}
