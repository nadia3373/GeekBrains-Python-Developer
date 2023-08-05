from flask import Flask, render_template, request, jsonify

app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/process', methods=['POST'])
def process():
    data = request.get_json()
    if data and 'message' in data:
        message = data['message']
        response = f"Вы нажали кнопку и передали сообщение: '{message}'"
    else:
        response = "Вы нажали кнопку без передачи сообщения."
    return jsonify({"response": response})

if __name__ == '__main__':
    app.run(debug=True)