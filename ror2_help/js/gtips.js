const Gtips = [
	{
		id: 1,
		num: 'CatGamer',
		hour: '420 in game hours',
		tip: 'Показатель "урон в секунду"  символизирует урон, нансимый врагам, в единицу времени.',
	},
	{
		id: 2,
		num: 'CatGamer',
		hour: '420 in game hours',
		tip: 'Для оптимального игрового процесса поддерживаете запас вашего здоровья выше 0.',
	},
	{
		id: 3,
		num: 'CatGamer',
		hour: '420 in game hours',
		tip: 'Шанс успеха зависит от вашего выбора персонажа во всех случаях, кроме тех, когда успех не зависит от выбора персонажа.',
	},
	{
		id: 4,
		num: 'CatGamer',
		hour: '420 in game hours',
		tip: 'Не играйте за рулём автомобиля.',
	},
	{
		id: 5,
		num: 'Based-Chaos',
		hour: '1394 in game hours',
		tip: 'Чтобы победить босса наносите ему урона пока его полоска здоровья не окажется на 0.',
	},
	{
		id: 6,
		num: 'Based-Chaos',
		hour: '1394 hours',
		tip: 'Быстрее двигаешься - быстрее проходишь игру.',
	},
];

const Gnum = document.getElementById('Gnum');
const Ghour = document.getElementById('Ghour');
const Gtip = document.getElementById('Gtip');

const GpastB = document.querySelector('.Gpast');
const GnextB = document.querySelector('.Gnext');

let currItemG = 0;

window.addEventListener('DOMContentLoaded', function () {
	const item = Gtips[currItemG];
	Gnum.textContent = item.num;
	Ghour.textContent = item.hour;
	Gtip.textContent = item.tip;
});

function showTipG(ne) {
	const item = Gtips[ne];
	Gnum.textContent = item.num;
	Ghour.textContent = item.hour;
	Gtip.textContent = item.tip;
}

GnextB.addEventListener('click', function(){
	currItemG++;
	if (currItemG > Gtips.length - 1){
		currItemG = 0;
	}
	showTipG(currItemG);
});

GpastB.addEventListener('click', function(){
	currItemG--;
	if (currItemG < 0){
		currItemG = Gtips.length-1;
	}
	showTipG(currItemG);
});
