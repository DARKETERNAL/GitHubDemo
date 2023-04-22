using System.Collections;
using UnityEngine;

public class InstanceCreator : MonoBehaviour
{
    [SerializeField]
    private float recycleTime = 3F;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(RecyclePoolable(PoolFacade.Instance.RetrieveObject(typeof(PoolableGameObject))));
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            IPoolable currentVFX = PoolFacade.Instance.RetrieveObject(typeof(SimpleVFX));
            (currentVFX as SimpleVFX).StartVFX();
            StartCoroutine(RecyclePoolable(currentVFX));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            VFXPool.Instance.gameObject.AddComponent<VFXLogger>();
        }
    }

    private IEnumerator RecyclePoolable(IPoolable obj)
    {
        yield return new WaitForSeconds(recycleTime);
        PoolFacade.Instance.RecycleObject(obj);
    }
}