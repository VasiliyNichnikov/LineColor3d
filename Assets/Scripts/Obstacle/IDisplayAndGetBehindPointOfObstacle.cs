using UnityEngine;

public interface IDisplayAndGetBehindPointOfObstacle
{
    Transform Point { get; set; }
    IParameterObstacle[] GetArrayParameterObstacles();
}
