using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SimpleVFX : MonoBehaviour, IPoolable
{
    [SerializeField]
    private ParticleSystem ps;

    public void StopVFX()
    {
        ps.Stop();
        gameObject.SetActive(false);
    }

    public void StartVFX()
    {
        gameObject.SetActive(true);
        ps.Play();
    }

    // Start is called before the first frame update
    private void Awake()
    {
        if (ps == null)
        {
            ps = GetComponent<ParticleSystem>();
        }
    }

    public void PrepareForRetrieve()
    {
        gameObject.transform.parent = null;
    }

    public void PrepareForRecycle(Transform parent)
    {
        gameObject.SetActive(false);
        StopVFX();
        transform.parent = parent;
        transform.position = parent.position;
        transform.rotation = Quaternion.identity;
    }
}