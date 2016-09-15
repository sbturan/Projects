using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for NavigasyonNesnesi
/// </summary>
public class NavigasyonNesnesi
{
    private string baslik;
    public string Baslik
    {
        get { return baslik; }
        set { baslik = value; }
    }

    private string url;
    public string Url
    {
        get { return url; }
        set { url = value; }
    }

    public enum TargetType
    {
        _blank,
        _self
    }
    private TargetType target;
    public TargetType Target
    {
        get { return target; }
        set { target = value; }
    }

    public NavigasyonNesnesi(string nBaslik, string nUrl, TargetType nTarget)
    {
        baslik = nBaslik;
        url = nUrl;
        target = nTarget;
    }
}