using NUnit.Framework;
using System.Collections;
using UnityEngine;

//using UnityEngine;
using UnityEngine.TestTools;

public class PlayTests
{
    private const int CHARACTER_START_HP = 100;

    private int[] testArray = new int[] { 1, 2, 3 };

    private TestCharacter character;

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestCharacterApplyDamage()
    {
        Assert.AreEqual(CHARACTER_START_HP, character.HP);

        for (int i = 0; i < 25; i++)
        {
            character.ApplyDamage(1);
            yield return new WaitForSeconds(0.2F);
        }
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        Assert.AreEqual(character.HP, 75);
    }

    [Test]
    public void TestCharacterEquip()
    {
        TestGear wpn1 = MonoBehaviour.Instantiate(Resources.Load<TestWeapon>("Wpn1"), Vector3.zero, Quaternion.identity);
        TestGear wpn2 = MonoBehaviour.Instantiate(Resources.Load<TestWeapon>("Wpn"), Vector3.zero, Quaternion.identity);

        TestGear arm1 = MonoBehaviour.Instantiate(Resources.Load<TestArmor>("Arm1"), Vector3.zero, Quaternion.identity);
        TestGear arm2 = MonoBehaviour.Instantiate(Resources.Load<TestArmor>("Arm"), Vector3.zero, Quaternion.identity);

        Assert.IsTrue(character.EquipGear(wpn1));
        Assert.IsFalse(character.EquipGear(wpn2));

        Assert.IsTrue(character.EquipGear(arm1));
        Assert.IsFalse(character.EquipGear(arm2));
    }

    [Test]
    public void TestPureObject()
    {
        TestPureObject tpo = new TestPureObject();

        Assert.IsTrue(tpo.IsAlwaysTrue());
    }

    [UnityTest]
    public IEnumerator TestCharacterKill()
    {
        Assert.AreEqual(100, character.HP);

        character.ApplyDamage(100);

        yield return null;

        Assert.IsNull(character);
    }

    [UnitySetUp]
    public IEnumerator Setup()
    {
        character = MonoBehaviour.Instantiate(Resources.Load<TestCharacter>("Character"), Vector3.zero, Quaternion.identity);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        character = null;
    }
}