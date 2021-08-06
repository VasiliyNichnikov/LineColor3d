using FluentAssertions;
using NUnit.Framework;
using UnityEngine;

public class TestCalculatorTimeAnimation
{
    private Vector2 _direction;
    private CalculatorTimeAnimation _timeAnimation;

    [SetUp]
    public void SetUp()
    {
        _direction = new Vector2(0.1f, -0.5f);
        _timeAnimation = new CalculatorTimeAnimation();
    }
    
    [Test]
    public void WhenChangingValuesTimeXAndTimeY_AndDirection_Vector2_01_Minus05_ThenTimeXShouldBe01()
    {
        // ACT
        _timeAnimation.ChangingValuesTimeXAndTimeY(_direction);
        
        // ASSERT
        _timeAnimation.TimeX.Should().Be(0.1f);
    }
    
    [Test]
    public void WhenChangingValuesTimeXAndTimeY_AndDirection_Vector2_01_Minus05_ThenTimeYShouldBeZero()
    {
        // ACT
        _timeAnimation.ChangingValuesTimeXAndTimeY(_direction);
        
        // ASSERT
        _timeAnimation.TimeY.Should().Be(0f);
    }

    [Test]
    public void WhenResetingSaveTimeXAndSaveTimeY_AndChangingValuesTimeXAndTimeY_ThenSaveTimeXShouldBeTimeX()
    {
        // ARRANGE
        _timeAnimation.ChangingValuesTimeXAndTimeY(_direction);
        
        // ACT
        _timeAnimation.ResetingSaveTimeXAndSaveTimeY();
        
        // ASSERT
        _timeAnimation.SaveTimeX.Should().Be(_timeAnimation.TimeX);
    }
    
    
    [Test]
    public void WhenResetingSaveTimeXAndSaveTimeY_AndChangingValuesTimeXAndTimeY_ThenSaveTimeYShouldBeTimeY()
    {
        // ARRANGE
        _timeAnimation.ChangingValuesTimeXAndTimeY(_direction);
        
        // ACT
        _timeAnimation.ResetingSaveTimeXAndSaveTimeY();
        
        // ASSERT
        _timeAnimation.SaveTimeY.Should().Be(_timeAnimation.TimeY);
    }
}
