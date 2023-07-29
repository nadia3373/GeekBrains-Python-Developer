document.addEventListener("DOMContentLoaded", function () {
    const button = document.getElementById("my-button") as HTMLButtonElement;
    const output = document.getElementById("output-text") as HTMLParagraphElement;

    button.addEventListener("click", function () {
        const message = prompt("Введите сообщение:");
        if (message !== null) {
            fetch("/process", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ "message": message }),
            })
            .then(response => response.json())
            .then(data => {
                output.textContent = data.response;
            })
            .catch(error => {
                console.error("Произошла ошибка:", error);
            });
        }
    });
});
