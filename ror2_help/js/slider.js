let lvle = document.getElementById('lvl');
let markerv = document.getElementById('marker');

markerv.innerHTML = "Selected lvl:" + lvle.value;

lvle.oninput = function() {
  markerv.innerHTML = "Selected lvl:" +  this.value;
}
