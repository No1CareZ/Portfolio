const itli = [
	{
		id: 1,
		name: "aid-id",
	},
	{
		id: 2,
		name: "bear-id",
	},
	{
		id: 3,
		name: "glasses-id",
	},
	{
		id: 4,
		name: "knife-id",
	},
	{
		id: 5,
		name: "nate-id",
	},
	{
		id: 6,
		name: "speed-id",
	},
	{
		id: 7,
		name: "cool_gl-id",
	},
	{
		id: 8,
		name: "cool_kn-id",
	},
	{
		id: 9,
		name: "luck-id",
	},
];

const time = [1, 3.5, 7, 10.5, 14, 17.5, 21, 24.5, 28, 31.5];
const dataz = [];
const ate = 3;
var dif;

const start = document.getElementById('submit');

var canvas = document.getElementById('myChart');
var newchart = new Chart(canvas, { });

var dif;
function checker(){	
		var inp = document.getElementsByName('diff');
		for (var i = 0; i < inp.length; i++) {
			if (inp[i].type == "radio" && inp[i].checked) {
				dif  = (inp[i].value);
			}
		}
	}

start.addEventListener('click', function(){
	const dataz = [];
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
	checker();
	
	time.forEach(function(item){
		var evhp = 480+(time.indexOf(item)*144/dif); //enemy dm
		var evdm = 20+(time.indexOf(item)*10/dif); //enemy hp
		var pure = 12+(lvl*2.4) // your dm
		var hp = 110+(lvl*33) // your hp
		var bear_n_insta = Math.pow((1-1/(0.15*bear+1)),(luck+1))+Math.pow((0.005*inst),(luck+1));
		var speed = 0.75*Math.pow(0.85,speedz);
		var heal = dif*(hp*0.05*aid + 5 + 20*(aid == 0 ? 0 : 1 ))/2;
		var max_chain = (1+1.5*cool*3+(knife == 0 ? 0 : Math.pow(2.4,knife))+1.8*nate)*pure*(crit >= 10 ? 2 : (1+crit*0.1));
		var ticks = Math.ceil((evhp*0.75*2*speed/(max_chain+pure))/ate);
		var ind = 0; //survived hits
		var check = 0;
		for (var i = 0; i < ticks; i++){
			hp = (hp == 110+lvl*33 ? hp : hp + heal);
			if (evdm > hp){
				if (hp/(110+lvl*33) >= 0.95){
					ind+=1;
					hp=0.05*hp;
				}
				else if (heal !=0){
					ind += bear_n_insta;
					heal = 0;
					check = i;
				}
				else {
					ind = bear_n_insta*Math.pow(1-bear_n_insta, i-check) + ind;
				}
			}
			else {
				hp -= evdm;
				ind+=1;
			}
		}
		
		dataz.push(ind/ticks);
		
	});
	
	newchart.destroy();
	newchart = new Chart(canvas, {
		type: "line",
		data:{
			labels: time,
			datasets:[{
				data: dataz,
				borderColor: "rgba(255, 252, 179, 1)",
			}]
		},
		options: {
			legend: {display: false},
			scales: {
				yAxes: [{
					display: true,
					ticks: {
						suggestedMin: 0,
						beginAtZero: true,
						fontcolor: "rgba(255, 252, 179, 1)",
						fontFamily: "BOM",
						fontSize: 16,
					}
				}],
				xAxes: [{
					display: true,
					ticks: {
						fontcolor: "rgba(255, 252, 179, 1)",
						fontFamily: "BOM",
						fontSize: 16,
					}
				}]
			}
		}
	});
});
