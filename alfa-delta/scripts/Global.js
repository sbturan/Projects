function UpperMe(evt, langCode) {
  // Olay nesnesi g�nderilmemi� ise (Micresoft IE i�in) evt olay nesnesi olu�turuluyor...
  var evt = (evt) ? evt : ((window.event) ? window.event : null);

  // Bas�lan tu� de�eri al�n�yor...
  var PressedKey = (evt.charCode) ? evt.charCode : evt.keyCode;

  // Dil kodu g�nderilmemi� ise TR olarak kabul ediliyor...
  langCode = ((!langCode) ? "TR" : langCode.toUpperCase());

  // Bas�lan tu� b�y�k harfe �evrilebilecek bir karakter de�ilse ��k�l�yor...
  if (PressedKey < 97 || (langCode == "TR" && (PressedKey == 286 || PressedKey == 220 || PressedKey == 350 || PressedKey == 304 || PressedKey == 214 || PressedKey == 199))) return;

  // Browser Microsoft �r�n� ise isIE degeri do�ru de�ilse yaln�� yap�l�yor...
  var isIE = (navigator.appName.indexOf("Microsoft") > -1 ? true : false);

  // B�y�lt�lecek harler i�in dizi haz�rlan�yor...
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
    // �evirme i�lemi T�rk�e alfabe i�in yap�lacak ise...
    // ��i���� karakterleri ������I karakterlerine �eviriliyor...
    UpperCharArray[287] = 286;
    UpperCharArray[252] = 220;
    UpperCharArray[351] = 350;
    UpperCharArray[105] = 304;
    UpperCharArray[246] = 214;
    UpperCharArray[231] = 199;
    UpperCharArray[305] = 73;
  }
  else {
    // �evirme i�lemi �ngilizce alfabe i�in yap�lacak ise...
    // ��i���� karakterleri UGISCOI karakterlerine �eviriliyor...
    UpperCharArray[287] = 71;
    UpperCharArray[252] = 85;
    UpperCharArray[351] = 83;
    UpperCharArray[105] = 73;
    UpperCharArray[246] = 79;
    UpperCharArray[231] = 67;
    UpperCharArray[305] = 73;
    // ������ karakterleri UGISCO karakterlerine �eviriliyor...
    UpperCharArray[286] = 71;
    UpperCharArray[220] = 85;
    UpperCharArray[350] = 83;
    UpperCharArray[304] = 73;
    UpperCharArray[214] = 79;
    UpperCharArray[199] = 67;
  }

  // Bas�lan karakter i�in d�nd�r�lecek b�y�k harf karakteri belirleniyor...
  var UpperChar = UpperCharArray[PressedKey];

  // Kullan�lan Browser kontrol edilerek belirlenen b�y�k harf karakteri d�nd�r�l�yor...
  if (isIE) {
    evt.keyCode = UpperChar;
  }
  else {
    // Tu�a basma olay� iptal edilip b�y�k harf kodu i�eren yeni tu�a basma olay� yarat�l�yor...
    var newEvt = document.createEvent("KeyEvents");
    newEvt.initKeyEvent("keypress", true, true, document.defaultView, evt.ctrlKey, evt.altKey, evt.shiftKey, false, 0, UpperChar);
    evt.preventDefault();
    evt.target.dispatchEvent(newEvt);
  }
}