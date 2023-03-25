using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class samScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(sam());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator sam()
    {
        Debug.Log("Sam estuvo aquí");
        Debug.Log("Y cancelará scripting en 3");
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        
    }
}
