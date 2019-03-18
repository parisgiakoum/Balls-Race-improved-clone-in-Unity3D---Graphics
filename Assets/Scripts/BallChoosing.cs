using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallChoosing : MonoBehaviour {

	public void Basketball()
    {
        PlayerController.ball = 0;
    }

    public void Beachball()
    {
        PlayerController.ball = 1;
    }

    public void BlackBall()
    {
        PlayerController.ball = 2;
    }

    public void BlueBall()
    {
        PlayerController.ball = 3;
    }

    public void DarkRedBall()
    {
        PlayerController.ball = 4;
    }

    public void DarkYellowBall()
    {
        PlayerController.ball = 5;
    }
    public void DeepPurpleBall()
    {
        PlayerController.ball = 6;
    }

    public void DiscoBall()
    {
        PlayerController.ball = 7;
    }

    public void EarthBall()
    {
        PlayerController.ball = 8;
    }

    public void GalaxyBall()
    {
        PlayerController.ball = 9;
    }

    public void GreenBall()
    {
        PlayerController.ball = 10;
    }

    public void LightBlueBall()
    {
        PlayerController.ball = 11;
    }


    public void MarsBall()
    {
        PlayerController.ball = 12;
    }

    public void MoonBall()
    {
        PlayerController.ball = 13;
    }

    public void OrangeBall()
    {
        PlayerController.ball = 14;
    }

    public void Softball()
    {
        PlayerController.ball = 15;
    }

    public void SunBall()
    {
        PlayerController.ball = 16;
    }

    public void TennisBall()
    {
        PlayerController.ball = 17;
    }

    public void RandomBall()
    {
        PlayerController.ball = Random.Range(0, 17);
    }
}

