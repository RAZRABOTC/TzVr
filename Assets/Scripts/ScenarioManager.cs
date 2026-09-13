using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    [SerializeField] private Scenario _initialScenario;

    public void Start()
    {
        _initialScenario.StartScenario();
    }
}
