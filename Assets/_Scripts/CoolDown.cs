using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public IEnumerator SimpleCooldown(float time, System.Action<bool> callback)
    {
        yield return new WaitForSeconds(time);
        callback(true);
    }
}
