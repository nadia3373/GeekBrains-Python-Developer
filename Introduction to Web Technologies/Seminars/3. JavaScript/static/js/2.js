document.querySelector("#main-button").addEventListener("click", function listener(e) {
    greet(takeinput());
    e.target.removeEventListener("click", listener);
    e.target.innerHTML = "Нажмите, чтобы повторить";
    e.target.addEventListener("click", () => {
        window.location.href = "1.html";
    });
});

function greet(name) {
    console.log(`Добро пожаловать, ${name}!`);
}

function takeinput() {
    return prompt("Представьтесь, пожалуйста");
}