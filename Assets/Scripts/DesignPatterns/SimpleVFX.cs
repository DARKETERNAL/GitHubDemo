using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SimpleVFX : MonoBehaviour
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
}