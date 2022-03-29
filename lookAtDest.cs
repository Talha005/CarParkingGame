using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class lookAtDest : MonoBehaviour
{

	public List<Transform> path;
	Transform PathGroup;
    public Transform Target;
    public bool smooth = true;
    public float damping = 6.0f;
	public int counter = 0;
	public float DstanceFromPoint=1;
    public InGameManager GM;
    bool parkingLevelOnly;
    // Use this for initialization
    void Start()
	{
        Invoke("GetStarted",0.6f);

	}

    public void GetStarted()
    {
        PathGroup = GM.LevlesScript[GM.currentLevel].checkpoints;
        GetPathPoints();
        Target = path[counter];
    }



    void LateUpdate()
    {
		
        if (Target != null)
        {
            if (smooth)
            {
				
                var lookPos = Target.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
				rotation.x = 0;
				transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            }
            else
            {
                transform.LookAt(Target);
            }

        }

    }


	void GetPathPoints()
	{
		Transform[] path_objs = PathGroup.GetComponentsInChildren<Transform> ();
		path = new List<Transform> ();

		foreach(Transform path_obj in path_objs) 
		{
			if(path_obj != PathGroup)
			{
				path.Add(path_obj);
			}
		}
	} 



}

