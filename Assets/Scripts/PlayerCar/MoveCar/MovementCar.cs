using UnityEngine;

public class MovementCar : MonoBehaviour
{
    public MovementCarForward MovementForward => _movementForward;
    public MovementCarBack MovementBack => _movementBack;
    public MovementCarStartAndEndPositions Positions => _positions;
    public Transform Transform => _thisTransorm;

    [SerializeField] private MovementCarForward _movementForward;
    [SerializeField] private MovementCarBack _movementBack;
    [SerializeField] private MovementCarStartAndEndPositions _positions;

    private IMoveCarState _state;
    private Transform _thisTransorm;

    private void Start()
    {
        _thisTransorm = transform;
        Vector3 startPosition = Positions.StartPosition;
        _thisTransorm.position = startPosition;
        MovementForward.Speed = _movementForward.Max;
        SetState(new MovementCarStraightLineState());
    }

    private void Update()
    {
        ToRunState();
    }

    public void SetState(IMoveCarState s) => _state = s;

    private void ToRunState() => _state.ToRun(this);
}