using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using DG.Tweening;

public class DamageTextAnimation : MonoBehaviour
{
    public async void Animation()
    {
        if (TryGetComponent<TextMeshProUGUI>(out var textMeshProUGUI))
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    this.transform.DOLocalMoveY(Random.Range(230,358f), 0.4f);
                    this.transform.DOLocalMoveX(Random.Range(230, 358f), 0.4f);
                    break;
                case 1:
                    this.transform.DOLocalMoveY(Random.Range(230, 358f), 0.4f);
                    this.transform.DOLocalMoveX(Random.Range(-230, -358f), 0.4f);
                    break;
                case 2:
                    this.transform.DOLocalMoveY(Random.Range(-230, -358f), 0.4f);
                    this.transform.DOLocalMoveX(Random.Range(230, 358f), 0.4f);
                    break;
                case 3:
                    this.transform.DOLocalMoveY(Random.Range(-230, -358f), 0.4f);
                    this.transform.DOLocalMoveX(Random.Range(-230, -358f), 0.4f);
                    break;
            }

            await Task.Delay(250);

            textMeshProUGUI.text = " ";

            this.transform.DOLocalMoveY(-(this.transform.localPosition.y/2f), 1f);
            this.transform.DOLocalMoveX(-(this.transform.localPosition.x/2f), 1f);
        }
    }

}
