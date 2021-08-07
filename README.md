# Catálogo de jogos

Feito em .NET, e para tanto, foi preciso seguir os seguintes passos.

* Criação do projeto base:
```
dotnet new webapi -o (nomedoprojeto)
```

A partir daqui, cada comando é executado dentro da pasta do projeto.

* Imposição do certificado HTTPS (pode ser diferente no Linux, pode necessitar de passos adicionais no Firefox):
```
dotnet dev-certs https --trust
```

* Instalação do pacote Swashbuckle para o Swagger:
```
dotnet add package Swashbuckle.AspNetCore
```

Depois de configurado no ```Startup.cs```, o Swagger já pode ser utilizado com o template do WeatherForecast.

Após remover os arquivos deste último, adiciona-se mais um pacote, o do Entity Framework:

```
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```

Daí então define-se o model e cria-se cada operação do controller.

A partir daqui, torna-se desejável criar mais camadas intermediárias entre eles.

![Imgur](https://i.imgur.com/3e7Q4E7.png)

https://digitalinnovation.one/bootcamps/everis-new-talents-net
