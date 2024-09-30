using UnityEngine;

namespace Chapter.Observer
{
    public class Credits : MonoBehaviour
    {
        public void Quit()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }

}
