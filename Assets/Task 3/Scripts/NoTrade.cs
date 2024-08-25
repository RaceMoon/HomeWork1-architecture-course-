using UnityEngine;

public class NoTrade: ISeller
{
  public void Trade()
    {
        Debug.Log("Я слышал, что ты обидел котенка, не желаю с тобой торговать!");
    }
}
