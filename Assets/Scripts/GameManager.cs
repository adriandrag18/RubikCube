using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    private GameObject[][][] cube;
    
    [SerializeField] private float speed = 1f;

    [SerializeField] private List<Material> materials = new List<Material>();

    private Colors[] mapColors = {Colors.black, Colors.blue, Colors.green, Colors.orange, Colors.red, Colors.white, Colors.yellow};

    private float time;
    void Start()
    {
        List<Color> colorList = new List<Color>();
        foreach (var material in materials)
        {
            colorList.Add(material.color);
        }
        cube = new []
        {
            new []{new GameObject[3], new GameObject[3], new GameObject[3]},
            new []{new GameObject[3], new GameObject[3], new GameObject[3]},
            new []{new GameObject[3], new GameObject[3], new GameObject[3]}
        };
        var localTag = 1;
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                for (var k = 0; k < 3; k++, localTag++)
                {
                    cube[i][j][k] = GameObject.FindWithTag(localTag.ToString());
                    var piece = cube[i][j][k].GetComponent<Piece>();
                    List<Colors> list = new List<Colors>();
                    for (var l = 0 ; l < cube[i][j][k].transform.childCount; l++)
                    {
                        var children = cube[i][j][k].transform.GetChild(l);
                        children.localScale = transform.localScale * 0.95f;
                        list.Add(mapColors[colorList.IndexOf(children.GetComponent<MeshRenderer>().material.color)]);
                    }
                    // piece.AddPiece(list, localTag);
                    // if (localTag == 1)
                    //     Debug.Log
                }   
            }
        }
    }

    void Update()
    {
        if (time + 1/speed > Time.time)
            return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            time = Time.time;
            R();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            time = Time.time;
            L();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            time = Time.time;
            U();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            time = Time.time;
            D();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            time = Time.time;
            F();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            time = Time.time;
            B();
        }
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            Debug.Log("This hit at " + hit.transform.tag + " " + hit.point);
        }
    }

    private void R()
    {        
        List<GameObject> side = new List<GameObject>(9);
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
               side.Add(cube[i][j][2]);
        }

        cube[0][0][2] = side[2];
        cube[0][1][2] = side[5];
        cube[0][2][2] = side[8];
        cube[1][0][2] = side[1];
        cube[1][2][2] = side[7];
        cube[2][0][2] = side[0];
        cube[2][1][2] = side[3];
        cube[2][2][2] = side[6];
        
        StartCoroutine(Rotate(side, Vector3.right));
    }
    private void L()
    {
        List<GameObject> side = new List<GameObject>(9);
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                side.Add(cube[i][j][0]);
                // Debug.Log((side.Count - 1) + " " + side[side.Count - 1].transform.tag);
            }
        }

        cube[0][0][0] = side[6];
        cube[0][1][0] = side[3];
        cube[0][2][0] = side[0];
        cube[1][0][0] = side[7];
        cube[1][2][0] = side[1];
        cube[2][0][0] = side[8];
        cube[2][1][0] = side[5];
        cube[2][2][0] = side[2];

        StartCoroutine(Rotate(side, Vector3.left));
    }
    private void U()
    {
        List<GameObject> side = new List<GameObject>(9);
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++) {
                side.Add(cube[i][0][j]); 
                Debug.Log((side.Count - 1) + " " + side[side.Count - 1].transform.tag);
            }
        }

        cube[0][0][0] = side[2];
        cube[0][0][1] = side[5];
        cube[0][0][2] = side[8];
        cube[1][0][0] = side[1];
        cube[1][0][2] = side[7];
        cube[2][0][0] = side[0];
        cube[2][0][1] = side[3];
        cube[2][0][2] = side[6];

        StartCoroutine(Rotate(side, Vector3.up));
    }

    private void D()
    {
        List<GameObject> side = new List<GameObject>(9);
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
                side.Add(cube[i][2][j]);
        }

        cube[0][2][0] = side[6];
        cube[0][2][1] = side[3];
        cube[0][2][2] = side[0];
        cube[1][2][0] = side[7];
        cube[1][2][2] = side[1];
        cube[2][2][0] = side[8];
        cube[2][2][1] = side[5];
        cube[2][2][2] = side[2];

        StartCoroutine(Rotate(side, Vector3.down));
    }

    private void F()
    {
        List<GameObject> side = new List<GameObject>(9);
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
                side.Add(cube[0][i][j]);
        }

        cube[0][0][0] = side[6];
        cube[0][0][1] = side[3];
        cube[0][0][2] = side[0];
        cube[0][1][0] = side[7];
        cube[0][1][2] = side[1];
        cube[0][2][0] = side[8];
        cube[0][2][1] = side[5];
        cube[0][2][2] = side[2];

        StartCoroutine(Rotate(side, Vector3.back));
    }

    private void B()
    {
        List<GameObject> side = new List<GameObject>(9);
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
                side.Add(cube[2][i][j]);
        }

        cube[2][0][0] = side[2];
        cube[2][0][1] = side[5];
        cube[2][0][2] = side[8];
        cube[2][1][0] = side[1];
        cube[2][1][2] = side[7];
        cube[2][2][0] = side[0];
        cube[2][2][1] = side[3];
        cube[2][2][2] = side[6];

        StartCoroutine(Rotate(side, Vector3.forward));
    }
    IEnumerator Rotate(List<GameObject> side, Vector3 axis)
    {
        float total = 90;

        while (total > 0)
        {
            float angle = 90 * speed * Time.deltaTime;
            foreach (var pieces in side)
                pieces.transform.RotateAround(Vector3.zero, axis, total < angle ? total : angle);
            total -= angle;
            yield return null;
        }
    }
}