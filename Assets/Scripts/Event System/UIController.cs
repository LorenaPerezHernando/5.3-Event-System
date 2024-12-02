using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private Slider _slider;
	[SerializeField] private TextMeshProUGUI _pointsText;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	#endregion

	#region Public Methods
	public void UpdateSliderLife(float currentLife)
	{
		_slider.value = currentLife;
	}
	public void UpdatePoints(int currentPoints)
	{
		_pointsText.text = currentPoints.ToString();
	}
	#endregion

	#region Private Methods
	#endregion
}
