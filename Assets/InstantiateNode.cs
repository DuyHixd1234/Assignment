using Unity.VisualScripting;
using UnityEngine;
 
[UnitTitle("Instantiate Object")]
[UnitCategory("Custom")]
public class InstantiateNode : Unit
{
    [DoNotSerialize]
    public ValueInput prefab;

    [DoNotSerialize]
    public ValueInput position;

    [DoNotSerialize]
    public ValueInput rotation;

    [DoNotSerialize]
    public ValueOutput instantiatedObject;

    protected override void Definition()
    {
        prefab = ValueInput<GameObject>("Prefab");
        position = ValueInput<Vector3>("Position", Vector3.zero);
        rotation = ValueInput<Quaternion>("Rotation", Quaternion.identity);

        instantiatedObject = ValueOutput<GameObject>("InstantiatedObject", Instantiate);

        Requirement(prefab, instantiatedObject);
        Requirement(position, instantiatedObject);
        Requirement(rotation, instantiatedObject);
    }

    private GameObject Instantiate(Flow flow)
    {
        GameObject prefabValue = flow.GetValue<GameObject>(prefab);
        Vector3 positionValue = flow.GetValue<Vector3>(position);
        Quaternion rotationValue = flow.GetValue<Quaternion>(rotation);

        return Object.Instantiate(prefabValue, positionValue, rotationValue);
    }
}
