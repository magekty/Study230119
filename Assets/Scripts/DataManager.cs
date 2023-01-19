using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviourPun
{
    readonly private int[] colorArr = { 0, 1, 2, 3 };
    private int[] tempArry = { 0, 0, 0, 0 };
    private void Awake()
    {
        var obj = FindObjectsOfType<DataManager>();
        if(obj.Length == 1)
            DontDestroyOnLoad(gameObject);
    }

    [PunRPC]
    public void SetData(int[] _arr)
    {
        for (int i = 0; i < tempArry.Length; i++)
        {
            tempArry[i] = _arr[i];
        }
    }
    [PunRPC]
    public void StartDataRPC()
    {
        photonView.RPC("SetData", RpcTarget.MasterClient, tempArry);
    }
    public int SetColorToIndex()
    {
        for (int i = 0; i < tempArry.Length; i++)
        {
            if (tempArry[i] == 0)
            {
                tempArry[i] = 1;
                return i;
            }
        }
        return -1;
    }
    public int GetColorNum(int _idx)
    {
        for (int i = 0; i < colorArr.Length; i++)
        {
            if (i == _idx)
            {
                return colorArr[i];
            }
        }
        return -1;
    }
    public void DestroyColorIdex(int _idx)
    {
        for (int i = 0; i < tempArry.Length; i++)
        {
            if (i == _idx)
                tempArry[i] = 0;
        }
    }

}
