using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MotoScript : MonoBehaviour
{
    public WheelCollider[] collisorDasRodas = new WheelCollider[2];
    public Transform[] transformsDasRodas = new Transform[2];
    public Transform volante;
    public Transform Setvolante;


    public float maxVelocity;
    public Transform[] rotateSet;
    Rigidbody rgb;
    public float runTimeRotate;
  
    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
        rgb.mass = 500;
    }

    private void Update()
    {
        MotorSystem();
        setComands();
    }
    float rotate = 0;
    void MotorSystem()
    {

        volante.localEulerAngles = new Vector3(volante.localEulerAngles.x, -runTimeRotate, volante.localEulerAngles.z);
        Setvolante.localEulerAngles = new Vector3(Setvolante.localEulerAngles.x, -runTimeRotate, Setvolante.localEulerAngles.z);


        for (int i = 0; i < collisorDasRodas.Length; i++)
        {
            Quaternion quatRodas;
            Vector3 posRodas;
            collisorDasRodas[i].GetWorldPose(out posRodas, out quatRodas);
            transformsDasRodas[i].position = posRodas;
            transformsDasRodas[i].rotation = quatRodas;
        }
        collisorDasRodas[1].steerAngle = -runTimeRotate;
        if (Input.GetAxis("Vertical") > 0.1f || Input.GetAxis("Vertical") < -0.1f)
        {
            collisorDasRodas[0].motorTorque = maxVelocity * Input.GetAxis("Vertical");
        }
        else
        {
            collisorDasRodas[0].motorTorque = 0;
            collisorDasRodas[0].brakeTorque = 1000;
        }

        collisorDasRodas[0].brakeTorque = Input.GetAxis("Jump") * 1000;
       
        collisorDasRodas[0].brakeTorque = 500 * Input.GetAxis("Horizontal");
       
    }


    void setComands()
    {
        if (runTimeRotate > 0.1f || runTimeRotate < -0.1f)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, runTimeRotate);
        }
        else
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            runTimeRotate = Mathf.Lerp(runTimeRotate, -100, 2.2f * Time.deltaTime);
        }
        else
        {
            runTimeRotate = Mathf.Lerp(runTimeRotate, 0, 3.5f * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            runTimeRotate = Mathf.Lerp(runTimeRotate, 100, 2.2f * Time.deltaTime);
        }
        else
        {
            runTimeRotate = Mathf.Lerp(runTimeRotate, 0, 3.5f * Time.deltaTime);
        }
    }
}
