//asıl 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//a ve b yi 2 nokta arasında mı diye kontrol ederken kullanıyoruz

public class lineCreater : MonoBehaviour
{
    public List<GameObject> list;

    public static int a, b;
    public LineRenderer line;
    public GameObject parentObj;
    public GameObject child;
    GameObject newParentObj;
    GameObject lastParent;
    int lastA, lastB;
    int listCounter=0;

    List<int> sayilar = new List<int>();


    void Start()
    {
        StartCoroutine(waitForCreate());
        StartCoroutine(waitForCreate());
    }
    void Update()
    {
        // Debug.DrawLine(transform.position+Vector3.back, transform.position + Vector3.forward, Color.black);
        Debug.DrawLine(transform.position, transform.position + Vector3.forward, Color.black);
        Ray ray = new Ray(transform.position, transform.position + Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1f))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Destroy(newParentObj);
                //Destroy(hit.collider.gameObject.transform.parent.gameObject);
                lastA = -1;
                lastB = -1;
                restart(list[0].gameObject);
                restart(list[0].gameObject);
            }
        }
    }

    public void restart(GameObject destroyObj)
    {
        int randomPos = Random.Range(0, 850);

        lastA = a;
        lastB = b;
        a = randomPos;
        int counter=0;

        if (listCounter <= 4) { 
        a1:
            print("a::" + a);
            if (    (Mathf.Abs(a - lastA) < 200) )
            {
                a += 100;
                a = a % 850;
                b = b % 850;
                lastA = lastA % 900;
                lastB = lastB % 800;
                print("goto a1 a:" + a);
                goto a1;
            }
        }

        if (listCounter > 4)
        {
        a2:
            print("a::" + a);
            if (    (Mathf.Abs(a - lastA) < 200)    && (Mathf.Abs(sayilar[counter] - sayilar[counter + 3]) < 200) && (Mathf.Abs(sayilar[counter+1] - sayilar[counter + 4]) < 200)

                //&& ((Mathf.Abs(sayilar[counter-1] - sayilar[counter + 3]) < 200) && (Mathf.Abs(sayilar[counter-1] - sayilar[counter +4]) < 200
                //))
                )
            {
                a += 100;
                a = a % 850;
                b = b % 850;
                lastA = lastA % 900;
                lastB = lastB % 800;
                print("goto a1 a:" + a);
                goto a2;
            }
            counter += 3;
        }




            //print(line.positionCount);
            //Random.Range(0,line.positionCount-151)
            newParentObj = Instantiate(parentObj, Vector3.zero, Quaternion.identity);//istediğimiz noktada yebni bir obje olusturuyoruz
                                                                                 //int randomPos = Random.Range(0, lr.positionCount - 151);

        int f = Random.Range(70, 100);
        for (int x = 0; x < f; x++)
        {
            GameObject newChildObj = Instantiate(child, Vector3.zero, Quaternion.identity, newParentObj.transform);
            newChildObj.transform.position = line.GetPosition(a);
            a = a + 1;
        }
        b = a;

        newParentObj.GetComponent<LineRenderer>().positionCount = newParentObj.transform.childCount;
        for (int y = 0; y < newParentObj.transform.childCount; y++)
        {
            newParentObj.GetComponent<LineRenderer>()
                .SetPosition(y, newParentObj.transform.GetChild(y).transform.position);
        }
        if (lastA == -1)
        {
            lastA = a;
            lastB = b;
            list.Remove(destroyObj);
            list.Add(newParentObj);
            Destroy(destroyObj);
        }
        else
        {
            list.Remove(destroyObj);
            Destroy(destroyObj);
            list.Add(newParentObj);
        }
        sayilar.Add(a);
        sayilar.Add(lastA);
        listCounter += 2;

        print("a: " + a + "  last a" + lastA);
    }

    public void create()
    {
        lastA = a;
        lastB = b;
        int randomPos = Random.Range(0, line.positionCount - 151);
        a = randomPos;
        //print(line.positionCount);
        //Random.Range(0,line.positionCount-151)
        newParentObj = Instantiate(parentObj, Vector3.zero, Quaternion.identity);//istediğimiz noktada yebni bir obje olusturuyoruz
                                                                                 //int randomPos = Random.Range(0, lr.positionCount - 151);
        int f = Random.Range(80, 250);
        for (int x = 0; x < f; x++)
        {
            GameObject newChildObj = Instantiate(child, Vector3.zero, Quaternion.identity, newParentObj.transform);
            newChildObj.transform.position = line.GetPosition(randomPos);
            randomPos = randomPos + 1;
        }

        b = randomPos;
        newParentObj.GetComponent<LineRenderer>().positionCount = newParentObj.transform.childCount;
        for (int y = 0; y < newParentObj.transform.childCount; y++)
        {
            newParentObj.GetComponent<LineRenderer>()
                .SetPosition(y, newParentObj.transform.GetChild(y).transform.position);
        }
        list.Add(newParentObj);

    }
    IEnumerator waitForCreate()
    {
        yield return new WaitForSeconds(0.3f);
        create();

    }
}
