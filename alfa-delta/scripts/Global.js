function UpperMe(evt, langCode) {
  // Olay nesnesi gönderilmemiþ ise (Micresoft IE için) evt olay nesnesi oluþturuluyor...
  var evt = (evt) ? evt : ((window.event) ? window.event : null);

  // Basýlan tuþ deðeri alýnýyor...
  var PressedKey = (evt.charCode) ? evt.charCode : evt.keyCode;

  // Dil kodu gönderilmemiþ ise TR olarak kabul ediliyor...
  langCode = ((!langCode) ? "TR" : langCode.toUpperCase());

  // Basýlan tuþ büyük harfe çevrilebilecek bir karakter deðilse çýkýlýyor...
  if (PressedKey < 97 || (langCode == "TR" && (PressedKey == 286 || PressedKey == 220 || PressedKey == 350 || PressedKey == 304 || PressedKey == 214 || PressedKey == 199))) return;

  // Browser Microsoft ürünü ise isIE degeri doðru deðilse yalnýþ yapýlýyor...
  var isIE = (navigator.appName.indexOf("Microsoft") > -1 ? true : false);

  // Büyültülecek harler için dizi hazýrlanýyor...
  var UpperCharArray = new Array();
  for (i = 97; i <= 351; i++) {
    if (i <= 122) {
      UpperCharArray[i] = i - 32;
    }
    else {
      UpperCharArray[i] = i;
    }
  }

  if (langCode == "TR") {
    // Çevirme iþlemi Türkçe alfabe için yapýlacak ise...
    // üðiþçöý karakterleri ÜÐÝÞÇÖI karakterlerine çeviriliyor...
    UpperCharArray[287] = 286;
    UpperCharArray[252] = 220;
    UpperCharArray[351] = 350;
    UpperCharArray[105] = 304;
    UpperCharArray[246] = 214;
    UpperCharArray[231] = 199;
    UpperCharArray[305] = 73;
  }
  else {
    // Çevirme iþlemi Ýngilizce alfabe için yapýlacak ise...
    // üðiþçöý karakterleri UGISCOI karakterlerine çeviriliyor...
    UpperCharArray[287] = 71;
    UpperCharArray[252] = 85;
    UpperCharArray[351] = 83;
    UpperCharArray[105] = 73;
    UpperCharArray[246] = 79;
    UpperCharArray[231] = 67;
    UpperCharArray[305] = 73;
    // ÜÐÝÞÇÖ karakterleri UGISCO karakterlerine çeviriliyor...
    UpperCharArray[286] = 71;
    UpperCharArray[220] = 85;
    UpperCharArray[350] = 83;
    UpperCharArray[304] = 73;
    UpperCharArray[214] = 79;
    UpperCharArray[199] = 67;
  }

  // Basýlan karakter için döndürülecek büyük harf karakteri belirleniyor...
  var UpperChar = UpperCharArray[PressedKey];

  // Kullanýlan Browser kontrol edilerek belirlenen büyük harf karakteri döndürülüyor...
  if (isIE) {
    evt.keyCode = UpperChar;
  }
  else {
    // Tuþa basma olayý iptal edilip büyük harf kodu içeren yeni tuþa basma olayý yaratýlýyor...
    var newEvt = document.createEvent("KeyEvents");
    newEvt.initKeyEvent("keypress", true, true, document.defaultView, evt.ctrlKey, evt.altKey, evt.shiftKey, false, 0, UpperChar);
    evt.preventDefault();
    evt.target.dispatchEvent(newEvt);
  }
}