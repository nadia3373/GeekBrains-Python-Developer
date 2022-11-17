document.querySelector("#main-button").addEventListener("click", function listener(e) {
    convert();
    e.target.removeEventListener("click", listener);
    e.target.innerHTML = "Нажмите для перехода к следующему заданию";
    e.target.addEventListener("click", () => {
        window.location.href = "2.html";
    });
});

function convert() {
    let celsius = parseInt(prompt("Введите температуру в градусах Цельсия"));
    let fahrenheit = (celsius * 1.8 + 32).toFixed(2);
    alert(`Цельсий: ${celsius}, Фаренгейт: ${fahrenheit}`);
}
