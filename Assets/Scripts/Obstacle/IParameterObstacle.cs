using UnityEngine;

public interface IParameterObstacle
{
    Transform Transform { get; }
    ProvideBordersObject ProvideBorders { get; }
}
