function popgoster(id,gen,yuk,tur,prm,urlb){

   width =gen;
   height =yuk;
   var left=(screen.width-width)/5;
   var top=(screen.height-height)/4;
   if(prm=="E")
   {
    
    if(tur==3)
    {
      url=urlb;
      win = window.open(url,'sayfa'+id ,"status=yes,toolbar=no,menubar=no,location=no,scrollbars=no,left="+left+",top="+top+",height="+height+",width="+width);
    }
    
    else if(tur == 2)
    {
    url = urlb + '?id=' + id + "&gen=" + gen + "&yuk=" + yuk;
    win = window.open(url,'video',"status=yes,toolbar=no,menubar=no,location=no,scrollbars=no,left="+left+",top="+top+",height="+height+",width="+width);
    return;
    }
    
    else if (tur==1 )
    {
    url = urlb + '?id=' + id + "&gen=" + gen + "&yuk=" + yuk;
    win = window.open(url,'fotograf',"status=yes,toolbar=no,menubar=no,location=no,scrollbars=no,left="+left+",top="+top+",height="+height+",width="+width);
    return;
    }
    
    else if(tur==0)
    {
      url=urlb + '?ID=' + id;
      win = window.open(url,'sayfa'+id ,"status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,left="+left+",top="+top+",height="+height+",width="+width);
    }
    
    else
    { 
      return;
    }
    
    
    
  }
   

}

function eforurl()
{
  window.open ("http://www.eforyazilim.com","_blank","");

}
