//zad 1
let a = parseFloat(prompt("Podaj liczbę:"))
let b = parseFloat(prompt("Podaj liczbę:"))
let c = parseFloat(prompt("Podaj liczbę:"))

let p = document.getElementsByTagName("p");
let max = Math.max(a, b, c);
p[0].innerText += Math.max(a, b, c);
p[1].innerText += Math.min(a, b, c);
p[2].innerText += a + b + c - max;
p[3].innerText += Math.sqrt(a + b + c);