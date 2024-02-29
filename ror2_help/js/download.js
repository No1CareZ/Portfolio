const Cstart = document.getElementById('clip');

Cstart.addEventListener('click', function(){
	var aid = document.getElementById('aidclass').valueAsNumber;
	var bear = document.getElementById('bearclass').valueAsNumber;
	var knife = document.getElementById('knifeclass').valueAsNumber;
	var crit = document.getElementById('glassesclass').valueAsNumber;
	var nate = document.getElementById('nateclass').valueAsNumber;
	var speedz = document.getElementById('speedclass').valueAsNumber;
	var inst = document.getElementById('cool_glclass').valueAsNumber;
	var cool = document.getElementById('cool_knclass').valueAsNumber;
	var luck = document.getElementById('luckclass').valueAsNumber;
	var lvl = document.getElementById('lvl').valueAsNumber;
	var txt = aid+';:'+bear+';:'+knife+';:'+crit+';:'+nate+";:"+speedz +';:'+inst+";:"+cool+';:'+luck+";:"+lvl;
	navigator.clipboard.writeText(`${txt}`);
});
