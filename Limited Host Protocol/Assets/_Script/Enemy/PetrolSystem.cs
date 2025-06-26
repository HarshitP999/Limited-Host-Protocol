using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetrolSystem : MonoBehaviour
{
    public EnemyType Role;


    public List<Transform> targetPos;

    public int currentIndex = 0;


    public float moveSpeed;

    public float waitingTime = 2;

    bool isMoving = true;

   
    private void Start()
    {
       
        
            StartCoroutine(PetrolRoute());
        

    }

    IEnumerator PetrolRoute()
    {

        while (true) 
        { 

          Transform target = targetPos[currentIndex];

           

          while(Vector2.Distance(transform.position, target.position) > 0.2)

            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                yield return null;

            }
            yield return new WaitForSeconds(waitingTime);

            currentIndex = (currentIndex + 1) % targetPos.Count ;
        }


    }



    public enum EnemyType
    {
        Civilian,
        Scientist,
        Guard,


    }





}




