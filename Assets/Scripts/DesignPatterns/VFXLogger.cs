using System.Collections;
using UnityEngine;

public class VFXLogger : MonoBehaviour, IDecorator
{
    public int UseCount => -1;

    public void Destroy()
    {
        Destroy(this);
    }

    public void Execute()
    {
        print("Did something with VFX");
        StartCoroutine(InstantiateObjectCR());
    }

    public GameObject ExecuteWithGameObject()
    {
        return null;
    }

    private IEnumerator InstantiateObjectCR()
    {
        GameObject instance = Instantiate(Resources.Load("Character") as GameObject, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3F);
        Destroy(instance);
    }
}