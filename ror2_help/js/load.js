const Dstart = document.getElementById('put');
Dstart.addEventListener('click', function(){
	var li = document.getElementById('built').value;
	var arr = li.split(';:');
	if(arr.length == 9);
	document.getElementById('aidclass').value = arr[0];
	document.getElementById('bearclass').value = arr[1];
	document.getElementById('knifeclass').value = arr[2];
	document.getElementById('glassesclass').value = arr[3];
	document.getElementById('nateclass').value = arr[4];
	document.getElementById('speedclass').value = arr[5];
	document.getElementById('cool_glclass').value = arr[6];
	document.getElementById('cool_knclass').value = arr[7];
	document.getElementById('luckclass').value = arr[8];
	document.getElementById('lvl').value = arr[9];
	let markerv = document.getElementById('marker');
	markerv.innerHTML = "Selected lvl:" + arr[9];
});
