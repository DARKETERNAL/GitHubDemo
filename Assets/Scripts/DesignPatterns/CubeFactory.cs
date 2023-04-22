using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    private static CubeFactory instance;

    [SerializeField]
    private GameObject product;

    private int instanceCount;

    private IDecorator decorator;

    public static CubeFactory Instance { get => instance; private set => instance = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        decorator = GetComponent<IDecorator>();
    }

    public GameObject DeliverNewProduct()
    {
        GameObject productInstance = null;

        if (decorator == null)
        {
            productInstance = Instantiate(product, Vector3.zero, Quaternion.identity);
        }
        else
        {
            //Instantiate object through decorator
            productInstance = decorator.ExecuteWithGameObject();

            if (decorator.UseCount == 0)
            {
                decorator.Destroy();
                decorator = null;
            }
        }

        instanceCount += 1;
        productInstance.name = $"{productInstance.name}{instanceCount}";

        productInstance.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1F), Random.Range(0, 1F), Random.Range(0, 1F), 1F);

        return productInstance;
    }
}