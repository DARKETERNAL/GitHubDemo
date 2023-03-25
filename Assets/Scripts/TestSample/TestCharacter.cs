using UnityEngine;

public class TestCharacter : MonoBehaviour
{
    public int HP { get; private set; }

    public TestArmor Armor { get; private set; }
    public TestWeapon Weapon { get; private set; }

    private void Start()
    {
        HP = 100;
    }

    public void ApplyDamage(uint val)
    {
        HP -= (int)val;

        if (HP < 1)
        {
            Destroy(gameObject);
        }
    }

    public bool EquipGear(TestGear gear)
    {
        bool result = false;

        if (gear is TestArmor && Armor == null)
        {
            Armor = gear as TestArmor;
            result = true;
        }
        else if (gear is TestWeapon && Weapon == null)
        {
            Weapon = gear as TestWeapon;
            result = true;
        }

        return result;
    }
}