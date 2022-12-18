using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseBase<T>
{
    public int status { get; set; }
    public T item { get; set; }
    public List<string> statusTexts { get; set; }
    public int count { get; set; }
}
