const list = [
	{
		id: 1,
		img: "../static/im/items/aid.png",
		name: "aid",
	},
	{
		id: 2,
		img: "../static/im/items/bear.png",
		name: "bear",
	},
	{
		id: 3,
		img: "../static/im/items/glasses.png",
		name: "glasses",
	},
	{
		id: 4,
		img: "../static/im/items/knife.png",
		name: "knife",
	},
	{
		id: 5,
		img: "../static/im/items/nate.png",
		name: "nate",
	},
	{
		id: 6,
		img: "../static/im/items/speed.png",
		name: "speed",
	},
	{
		id: 7,
		img: "../static/im/items/cool_glasses.png",
		name: "cool_gl",
	},
	{
		id: 8,
		img: "../static/im/items/cool_knife.png",
		name: "cool_kn",
	},
	{
		id: 9,
		img: "../static/im/items/luck.png",
		name: "luck",
	},
];

const itemlist = document.querySelector('.item-list');

window.addEventListener('DOMContentLoaded', function() {
	let displayList = list.map(function(item){
		return `<article class = "grid-item">
					<div class = "item-list-sub">
						<div>
							<img src = ${item.img} class = "img"
							alt = ${item.name} />
						</div>
						<div>
							<input type = "number" id="${item.name}class" name="quantity" min="0" max="256" value="0" style = "width:4.25vw">
						</div>
					</div>
				</article>`;
	});
	displayList = displayList.join("");
	itemlist.innerHTML = displayList;
});
