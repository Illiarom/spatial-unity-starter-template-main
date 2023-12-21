using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airship_Control : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Скорость движения
    public float rotationSpeed = 2.0f; // Скорость поворота
    public float liftSpeed = 2.0f; // Скорость подъема/опускания

    private bool isInTriggerZone = false; // Флаг для проверки нахождения в зоне триггера

    void Update()
    {
        if (isInTriggerZone)
        {
            // Поднимаемся вверх при нажатии клавиши E
            if (Input.GetKey(KeyCode.E))
            {
                transform.Translate(Vector3.up * liftSpeed * Time.deltaTime);
            }

            // Опускаемся вниз при нажатии клавиши Q
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Translate(Vector3.down * liftSpeed * Time.deltaTime);
            }

            // Двигаемся вперед при нажатии клавиши W
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }

            // Двигаемся назад при нажатии клавиши S
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            }

            // Поворачиваем налево при нажатии клавиши A
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            }

            // Поворачиваем направо при нажатии клавиши D
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }
        }
    }

    // Вызывается, когда объект входит в триггерную зону
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AirshipTrigger"))
        {
            isInTriggerZone = true;
        }
    }


    // Вызывается, когда объект покидает триггерную зону
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AirshipTrigger"))
        {
            isInTriggerZone = false;
        }
    }
}
