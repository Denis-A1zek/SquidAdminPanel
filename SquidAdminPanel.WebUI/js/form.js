const form = document.querySelector('#userForm'); // выбираем форму по ее id
const url = 'https://localhost:7075/api/user'; // адрес, на который отправляем данные

form.addEventListener('submit', (event) =>{
      event.preventDefault();
      const formData = new FormData(form);
      const username = formData.get("name");
      const password = formData.get("password");
      
      const userRequest = { 
            Name: username, 
            Password: password 
          };

      fetch(url, {
            method: "POST",
            headers: {
                  'Content-Type': 'application/json'
                },
                body: JSON.stringify(userRequest)
            })
            .then(response => response.json())
            .then(data => {
            // Обработка полученных данных
            console.log(data);
            })
            .catch(error => {
                  
                  console.error(error);
            });

      
});