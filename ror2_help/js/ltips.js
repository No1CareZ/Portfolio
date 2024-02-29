const Ltips = [
	{
		id: 1,
		num: 'CatGamer',
		hour: '420 in game hours',
		tip: 'Продолжайте играть и исследовать, чтобы узнать мотивацию Джона Риска-Дождя.',
	},
	{
		id: 2,
		num: 'ShizVizor',
		hour: '69 in game hours',
		tip: 'Хорус не предовал.',
	},
	{
		id: 3,
		num: 'CatGamer',
		hour: '420 in game hours',
		tip: 'Вероятность осадков равна 0, если был объявлен ясный день.',
	},
	{
		id: 4,
		num: 'Avtobot',
		hour: '0 in game hours',
		tip: 'Что вы мне выслали?',
	},
	{
		id: 5,
		num: 'Based-Chaos',
		hour: '1394 in game hours',
		tip: 'Собирайте книжки.',
	},
	{
		id: 6,
		num: 'Mosquito of Tarkov',
		hour: '1948 in game hours',
		tip: '~BZZZZZZZZZ-Z-Z-Z.',
	},
];

const Lnum = document.getElementById('Lnum');
const Lhour = document.getElementById('Lhour');
const Ltip = document.getElementById('Ltip');

const LpastB = document.querySelector('.Lpast');
const LnextB = document.querySelector('.Lnext');

let currItemL = 0;

window.addEventListener('DOMContentLoaded', function () {
	const Litem = Ltips[currItemL];
	Lnum.textContent = Litem.num;
	Lhour.textContent = Litem.hour;
	Ltip.textContent = Litem.tip;
});

function showTipL(ne) {
	const Litem = Ltips[ne];
	Lnum.textContent = Litem.num;
	Lhour.textContent = Litem.hour;
	Ltip.textContent = Litem.tip;
}

LnextB.addEventListener('click', function(){
	currItemL++;
	if (currItemL > Ltips.length - 1){
		currItemL = 0;
	}
	showTipL(currItemL);
});

LpastB.addEventListener('click', function(){
	currItemL--;
	if (currItemL < 0){
		currItemL = Ltips.length-1;
	}
	showTipL(currItemL);
});
