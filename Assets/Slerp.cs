using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Slerp : MonoBehaviour
{
    [SerializeField] private List<Vector3> dots;
    public LineRenderer line;
    /*[HideInInspector] farkları hide da saklnaıyor serialized field da olanlar sadece bulundugu script ve inspectorden değiştiirelebiliniur*/

    public Vector3 lastPos;
    public int lastPosCount;

    void Start()
    {
        StartCoroutine(waitForCreate());
    }
    void Update()
    {
        if(Vector3.Distance(transform.position,lastPos)>1f)
        {
            transform.position = Vector3.Lerp(transform.position, lastPos, 3999f*Time.deltaTime);//hız
        }
        else
        {
            transform.position = lastPos;
            for (int i = 0; i < dots.Count; i++)
            {
                if (dots[i] != dots[dots.Count - 1])
                {
                    if (dots[i] == lastPos)
                    {
                        lastPos = dots[i + 1];
                        lastPosCount = i;
                        break;
                    }
                }
                else{
                    lastPos = dots[0];
                    lastPosCount = 0;

                }
            }
        }

    }
    IEnumerator waitForCreate()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < line.positionCount; i++)
        {
            dots.Add(line.GetPosition(i));
        }
        lastPos = dots[1];
    }

}
