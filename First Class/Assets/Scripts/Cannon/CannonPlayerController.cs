using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonPlayerController : MonoBehaviour
{
    const float MINX = -8f;

    const float MAXX = 8f;

    float _speedX = 20f;

    float _triggerSpeed = 30f;

    float _triggerAngle;

    float _barValue;

    int _trayectoryVertices = 20;

    Vector3 _deltaPosition;

    Vector3 _mousePosition;

    LineRenderer _trayectory;

    public GameObject CannonBallPrefab;

    public GameObject ProgressBar;


    // El awake es la primera funcion que se ejecuta, incluso primero que la funcion start
    private void Awake()
    {
        _trayectory = GetComponent<LineRenderer>();
    }


    void Start()
    {
        _deltaPosition = new Vector3();

//        _trayectory.positionCount = _trayectoryVertices;
    }
    

    void Update()
    {
        _deltaPosition.y =0;

        _deltaPosition.z =0;

        _deltaPosition.x = Input.GetAxis("Horizontal") * _speedX * Time.deltaTime;

        gameObject.transform.Translate(_deltaPosition);

        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, MINX, MAXX), gameObject.transform.position.y, gameObject.transform.position.z);

        
        //Aqui trabajo la posicion del mouse

        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _deltaPosition.y = _mousePosition.y - gameObject.transform.position.y;

        _deltaPosition.x = _mousePosition.x - gameObject.transform.position.x;


        if (_deltaPosition.x < 0)
        {
            _triggerAngle = Mathf.PI /2;
        }


        else if (_deltaPosition.y < 0)
        {
            _triggerAngle = 0;
        }

        else
        _triggerAngle = Mathf.Atan(_deltaPosition.y / _deltaPosition.x);

        //unity maneja los angulos por defecto en radianes  
        //* Mathf.Rad2Deg esto lo utilizo para llevar de radianes a grados


        //Este primer if se encarga de aumentar la barra de carga mientras el usuario tenga
        //presionado el boton Fire1 y de irle agregando potencia al tiro mediante pingpong 
        if (Input.GetButton("Fire2"))
        {
            _barValue = Mathf.PingPong(Time.time,1) *100f;

            ProgressBar.GetComponent<ProgressBar>().BarValue = Mathf.PingPong(Time.time,1)*100f;
        }


        // El siguiente if es para cuando el usuario suerte el boton de Fire1 que es el click izquierdo
        // cuando lo suelte instanciara la bala de canion
        else if (Input.GetButtonUp("Fire2"))
        {
            Instantiate(CannonBallPrefab, gameObject.transform.position, Quaternion.identity).GetComponent<CannonBallBehaviour>().Shoot(_triggerSpeed * (_barValue/100), _triggerAngle);
        }


      /*  for (int i = 0; i < _trayectoryVertices; i++)
        {
            _trayectory.SetPosition(i, GetPosition((float)i / _trayectoryVertices, Mathf.Pow(_triggerSpeed,2) *Mathf.Sin(_triggerAngle * 2) /Mathf.Abs(Physics.gravity.y)));
        }*/

    }


    Vector3 GetPosition(float resolutionProportion, float xMaxDistance)
    {
        float xRelative = resolutionProportion * xMaxDistance;

        float yRelative = xRelative * Mathf.Tan(_triggerAngle) - (Mathf.Abs(Physics.gravity.y) * Mathf.Pow(xRelative,2)) / (2 *(_triggerSpeed * (_barValue /100) * _triggerSpeed * (_barValue /100) * Mathf.Cos(Mathf.Pow(_triggerAngle, 2))));

        return new Vector3(xRelative, yRelative);
    }
}
