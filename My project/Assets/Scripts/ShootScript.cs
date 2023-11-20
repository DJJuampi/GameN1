using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Transform Gun;
    public GameObject Bullet;
    public float BulletSpeed;
    public Transform ShootPoint;
    public float fireRate;
    float ReadyForNextShot;
    public GameObject pooledObject;
    public int poolSize;
    public PlayerMovement playerMovement;
    private List<GameObject> objectPool;
   

    private void Start()
    {
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation); ;
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    void Update()
    {
        
        FaceMouse();

        if (Input.GetMouseButton(0))
        {
            if (Time.time > ReadyForNextShot)
            {
                ReadyForNextShot = Time.time + 1 / fireRate;
                shoot();
            }
        }
    }

    void FaceMouse()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Gun.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void shoot()
    {

        //Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);

        GameObject BulletIns = GetPooledObject();
        BulletIns.SetActive(true);
        BulletIns.transform.position = ShootPoint.position;
        BulletIns.transform.rotation = ShootPoint.rotation;
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
        //playerMovement.Recoil();
        //Destroy(BulletIns, 3);
    }
    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        if(objectPool[poolSize - 1].activeInHierarchy == true){
            for (int i = 0; i < poolSize; i++)
                {
                    objectPool[i].SetActive(false);
                }
        }
        return null;
    }
}
