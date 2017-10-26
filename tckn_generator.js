function tcUret(){
	var t1 = Math.floor(Math.random()*10);
	if(t1 == 0) t1 = 1;
	if(t1 == 9) t1 = 8;
	var t2 = Math.floor(Math.random()*10);
	var t3 = Math.floor(Math.random()*10);
	var t4 = Math.floor(Math.random()*10);
	var t5 = Math.floor(Math.random()*10);
	var t6 = Math.floor(Math.random()*10);
	var t7 = Math.floor(Math.random()*10);
	var t8 = Math.floor(Math.random()*10);
	var t9 = Math.floor(Math.random()*10);
	var t11 = ((t1+t3+t5+t7+t9)*8)%10;
	var t10 = ((10 - (t1+t2+t3+t4+t5+t6+t7+t8+t9) % 10) + t11) % 10;
	var tc = '' + t1 + t2 + t3 + t4 + t5 + t6 + t7 + t8 + t9 + t10 + t11;
	if(confirm("Kopyalamak için OK'e basınız.\nT.C. Kimlik No: " + tc))
		copyToClipboardCrossbrowser(tc);
}

function vknUret(){
	var vk1 = Math.floor(Math.random()*10);
	//if(vk1 == 0) vk1 = 1;
	var vk2 = Math.floor(Math.random()*10);
	var vk3 = Math.floor(Math.random()*10);
	var vk4 = Math.floor(Math.random()*10);
	var vk5 = Math.floor(Math.random()*10);
	var vk6 = Math.floor(Math.random()*10);
	var vk7 = Math.floor(Math.random()*10);
	var vk8 = Math.floor(Math.random()*10);
	var vk9 = Math.floor(Math.random()*10);
	var v1 = (vk1 + 9) % 10;
	var v2 = (vk2 + 8) % 10;
	var v3 = (vk3 + 7) % 10;
	var v4 = (vk4 + 6) % 10;
	var v5 = (vk5 + 5) % 10;
	var v6 = (vk6 + 4) % 10;
	var v7 = (vk7 + 3) % 10;
	var v8 = (vk8 + 2) % 10;
	var v9 = (vk9 + 1) % 10;
	var v11 = (v1 * 512) % 9;
	var v22 = (v2 * 256) % 9;
	var v33 = (v3 * 128) % 9;
	var v44 = (v4 * 64) % 9;
	var v55 = (v5 * 32) % 9;
	var v66 = (v6 * 16) % 9;
	var v77 = (v7 * 8) % 9;
	var v88 = (v8 * 4) % 9;
	var v99 = (v9 * 2) % 9;
	if (v1 != 0 && v11 == 0) v11 = 9;
	if (v2 != 0 && v22 == 0) v22 = 9;
	if (v3 != 0 && v33 == 0) v33 = 9;
	if (v4 != 0 && v44 == 0) v44 = 9;
	if (v5 != 0 && v55 == 0) v55 = 9;
	if (v6 != 0 && v66 == 0) v66 = 9;
	if (v7 != 0 && v77 == 0) v77 = 9;
	if (v8 != 0 && v88 == 0) v88 = 9;
	if (v9 != 0 && v99 == 0) v99 = 9;
	var toplam = v11 + v22 + v33 + v44 + v55 + v66 + v77 + v88 + v99;
	if (toplam % 10 == 0) toplam = 0; else toplam = (10 - (toplam % 10));
	var vk10 = toplam;
	var vkn = '' + vk1 + vk2 + vk3 + vk4 + vk5 + vk6 + vk7 + vk8 + vk9 + vk10;
	if(confirm("Kopyalamak için OK'e basınız.\nVergi Kimlik No: " + vkn))
		copyToClipboardCrossbrowser(vkn);
}
