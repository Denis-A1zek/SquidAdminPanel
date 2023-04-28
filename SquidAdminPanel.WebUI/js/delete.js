function deleteUser(userName)
{
      console.log(userName);

      fetch("https://localhost:7075/api/user/"+userName, {
            method: "DELETE"})
            .then(response => response.json())
            .then(data => {
            // Обработка полученных данных
                  console.log(data);
            })
            .catch(error => {
                  
                  console.error(error);
            });
}