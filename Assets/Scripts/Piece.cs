using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Colors
{
    black, blue, green, orange, red, white, yellow
}

public class Piece : MonoBehaviour
{
    private Colors up;
    private Colors down;
    private Colors right;
    private Colors left;
    private Colors forword;
    private Colors back;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPiece(List<Colors> list, int localTag)
    {
        switch (localTag)
        {
            case 1:
                up = list[1];
                down = Colors.black;
                left = list[2];
                right = Colors.black;
                forword = list[3];
                back = Colors.black;
                break;
        }
    }
}
