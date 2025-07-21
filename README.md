

# API Planos de Refeições
 
API planos de refeições, é um projeto para criação de planos nutricionais para pacientes. 
<img width="677" height="406" alt="image" src="https://github.com/user-attachments/assets/bec8a6bf-690f-41a1-b993-8a7ec12865a8" />

## 🔥 Introdução

API foi criada com os métodos Http, com todos os endpoints do Http: Get, Post, Put, Delete.
Para realizar todas as operações, será necessário registrar e autenticar o um novo usuário.

### ⚙️ Pré-requisitos
* .Net Core versão 8.0 [.Net Core 6.0 Download](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0)
* Entity Framework Core versão 8.0 [Documentação](https://learn.microsoft.com/pt-br/ef/)
* Visual studio 2022, ou IDE que tenha suporte ao .Net 8.0 [Visual Studio 2022 Download](https://visualstudio.microsoft.com/pt-br/downloads/)
* Sql Server versão 2022 [Sql Server Download](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
* Sql Server Management Studio (SSMS) [SSMS Download](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
* Swagger [Documentação](https://swagger.io/)


### 🔨 Guia de instalação

Para utilizar este projeto, necessário instalar o Entity Framework, e configurar o banco de dados no arquivo appsettings.Development.json, e instalar as migrations para conexão com o banco de dados

Etapas para instalar:

```bash
dotnet tool install --global dotnet-ef
```
Passo 2:
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
Passo 3:
```bash
Install-Package Microsoft.EntityFrameworkCore.Design
```
Passo 4:
```bash
dotnet-ef migrations add (Nome da migration do projeto)
```

Passo 5:
```bash
dotnet-ef database update
```


## 🛠️ Executando os testes (caso tenha testes)

Para executar o projeto, para testes. Digite o seguinte comando no terminal do Visual Studio

```bash
dotnet watch run
```


## Coleção Postman para testar os end-points
* [Link](https://postman.co/workspace/My-Workspace~18c1055e-1838-4aea-81a0-58201ca1e7f7/collection/23562941-8b273bc6-74a8-4cc6-91cb-7a5973f017ec?action=share&creator=23562941)


## Autenticação ✒️
Para realizar a autenticação, será necessário acessar o endpoint "api/auth/register" para registrar um novo usuário. Os dados para cadastro são: E-mail, senha (password) e role (papel para nível de acesso ao sistema)
E-mail e senha, tem validações, sendo um e-mail no formato correto e senha com no mínimo seis caracteres

<img width="886" height="247" alt="image" src="https://github.com/user-attachments/assets/43e61aa2-9171-41a6-b817-129c68f5638c" />


### Login 💻
Para realizar o login para obter o token de acesso, o endpoint "api/auth/login", inserindo o dados registrados na api

<img width="886" height="344" alt="image" src="https://github.com/user-attachments/assets/d27f0343-3d88-4e26-99a0-1d26aebec46d" />

 
### Token de Acesso 🎲
O Token de acesso, estará disponível após a realização do login, no retorno de resposta da api
 

<img width="683" height="425" alt="image" src="https://github.com/user-attachments/assets/b80d3b75-1484-4632-82ec-f6fdfb56064d" />




# Endpoins 🚨
### Método get/api/patient?PageNumber=1&Pagesize=10 ⬅️
O método get/api/patient , irá retornar todos os clientes e seus logradouros cadastrados.

<img width="722" height="448" alt="image" src="https://github.com/user-attachments/assets/eab668bb-465b-4cd7-a0ed-cc0e024582c1" />

 
Há paginação na busca de pacientes, para evitar carregamento de muitos dados e assim queda de performance. Os valores padrão é de 10 dados por página.
Pode-se também buscar um paciente por Id

<img width="759" height="429" alt="image" src="https://github.com/user-attachments/assets/87d2d372-2c42-403a-b044-135a77531f37" />

 
Caso o Id não exista, será retornado 404 not-found

 <img width="689" height="375" alt="image" src="https://github.com/user-attachments/assets/0a412348-6937-4b0c-a979-50db9a7e16e4" />



### Método Post ➡️
O método Post, realiza a criação de um novo paciente, enviando dados através do corpo da requisição

<img width="756" height="309" alt="image" src="https://github.com/user-attachments/assets/17de6ce3-56aa-47a5-aaad-170d82e8fac1" />

 
Os campos de FullName DateOfBirth e IsActive, não são necessários
Todos os campos são obrigatórios.
Após a execução, a api irá retornar os dados criados. Status Code 201 Created

<img width="714" height="464" alt="image" src="https://github.com/user-attachments/assets/e74f6683-2d55-456e-99f7-bedf22d407bf" />

 

### Método Put/id ↗️
O método Put, irá atualizar um paciente, enviado dados através do corpo da requisição, e informando o id do cliente a ser atualizado.
Necessário preenchimento de todos os campos para atualização
 
Após a execução, a api irá retornar os dados atualizados. Status code 204 no content

<img width="783" height="386" alt="image" src="https://github.com/user-attachments/assets/c1714583-214f-439e-9d3d-a85ff6faf6fc" />



### Método Delete/id ❌
O método Delete, irá deletar um cliente do banco de dados através do id do cliente a ser deletado. Sendo uma operação soft-delete. Somente usuários com papel de Administrador poderá excluir um paciente
Usuário não permitido para executar a ação

<img width="689" height="339" alt="image" src="https://github.com/user-attachments/assets/a7df4037-d03b-457b-8160-db1ed709be77" />

 

Após a execução, a api irá retornar o Status Code 204 No Content

 <img width="831" height="436" alt="image" src="https://github.com/user-attachments/assets/5a0ef489-3038-4e0b-a2ef-32a639101110" />




## Endpoits de Food👷

### Método Get api/food  ⬅️

O Método Get, realiza a busca todos os alimentos cadastrados com paginação, para evitar lentidões e gargalos durante as buscas
No input número da página, é inserido a página atual, e o tamanho da página, a quantidade de dados para serem exibidos
Após a execução, o endpoint irá trazer os dados como foi solicitado
 

<img width="552" height="380" alt="image" src="https://github.com/user-attachments/assets/d8797cad-c85e-4381-bd26-1b5459994e32" />


### Método Get/ /id ⬅️
O método Get por id, irá trazer um alimento de acordo com o seu ID. Sendo necessário informar o ID desejado no input do endpoint

<img width="656" height="361" alt="image" src="https://github.com/user-attachments/assets/ab66d63b-e54e-46b8-9f14-f1ac93d48412" />


Após a execução, a api irá retornar o dados solicitado.
 


Caso o ID não exista, o endpoint irá retornar o Status Code 400 Bad Request 

<img width="697" height="381" alt="image" src="https://github.com/user-attachments/assets/84e79a04-9f02-4c0a-98db-6304eecac939" />

 

### Método Post/Food ➡️
O método Post, realiza a criação de um novo alimento, enviando dados através do corpo da requisição
Todos os campos são obrigatórios.
Após a execução, a api irá retornar os dados criados. Status Code 201 Created
 

<img width="644" height="435" alt="image" src="https://github.com/user-attachments/assets/765594ee-6234-4388-9403-d2fe8100f332" />


### Método Put/Food/id ↗️
O método Put, irá atualizar o alimento, enviado dados através do corpo da requisição, e informando o id do alimento a ser atualizado.
Necessário preenchimento de todos os campos para atualização

<img width="752" height="496" alt="image" src="https://github.com/user-attachments/assets/a9f20ea8-cdc1-40a4-ae75-439316c6b697" />

 

### Método Delete/Food /id ❌
O método Delete, irá deletar um alimento do banco de dados através do seu id. Sendo uma operação Irreversível
Após a execução, a api irá retornar o Status Code 204 No Content
<img width="1431" height="530" alt="image" src="https://github.com/user-attachments/assets/041f4fe7-43d6-41c8-9132-32c97adb263d" />


## Endpoits de Meal Plan #👷

### Método Get api/MealPlans/{id}  ⬅️
O método, busca um plano para um paciente no dia atual, através de Id do plano
 
<img width="600" height="384" alt="image" src="https://github.com/user-attachments/assets/3b80897f-b136-41fd-a08d-01a8abee0523" />


### Método Post api/MealPlans  ⬅️
O método cria um plano para um paciente, de acordo com o seu ID
Somente usuários com regras de Nutricionista podem criar planos

<img width="677" height="448" alt="image" src="https://github.com/user-attachments/assets/52af4d69-fa50-41d8-8572-cfbff5bdd7b4" />


 

### Método Post api/MealPlans{id}/Foods  ⬅️
Método para adicionar alimentos ao plano de um paciente, de acordo com o ID do paciente, ID da comida, com quantidade e unidade (g, kg)
Somente nutricionistas podem criar planos alimentares
<img width="759" height="305" alt="image" src="https://github.com/user-attachments/assets/fdc3dc6d-eef0-49fa-873d-8dab901af895" />


## Comando Docker

* Para criar uma imagem no Docker, é necessário criar um arquivo Dockerfile, na para raiz do projeto e colar os seguintes comandos
```Bash
# Estágio 1: Build (A Fábrica com o SDK completo)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos de projeto (.csproj) e restaura os pacotes NuGet
COPY ["mealPlansAPI/mealPlansAPI.csproj", "mealPlansAPI/"]
COPY ["Services/Services.csproj", "Services/"]
# Se você chamou de Repository, ajuste o nome da pasta e do .csproj aqui
COPY ["Repository.csproj", "ApplicationDBContext/"]
RUN dotnet restore "mealPlansAPI/mealPlansAPI.csproj"

# Copia todo o resto do código-fonte
COPY . .

# Compila o projeto
WORKDIR "/src/mealPlansAPI"
RUN dotnet build "mealPlansAPI.csproj" -c Release -o /app/build

# ---

# Estágio 2: Publish (O Empacotamento otimizado)
FROM build AS publish
RUN dotnet publish "mealPlansAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ---

# Estágio 3: Final (O Contêiner de Entrega, leve e otimizado)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia apenas os arquivos publicados do estágio anterior
COPY --from=publish /app/publish .

# Define o comando para iniciar a API quando o contêiner rodar
ENTRYPOINT ["dotnet", "mealPlansAPI.dll"]
```
execute o comando no terminal. Terminal precisa estar aberto na pasta raiz, onde se encontra o arquivo Dockerfile
```bash
docker build -t mealplans-api .
```


## Para utilizar o banco de dados no Docker no terminal

execute o comando
```bash
docker run -p 8081:8080 -e "ConnectionStrings:DefaultConnection=Server=host.docker.internal;Initial Catalog=MealPlan;Integrated Security=True;TrustServerCertificate=True" mealplans-api
```

*
*
*
*



## 📦 Tecnologias usadas:

* [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/tour-of-csharp/)
* [Entity Framework](https://learn.microsoft.com/pt-br/ef/core/get-started/overview/install)
* [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
* [Swagger](https://swagger.io/)



## 👷 Autores

* **Maurício Marcelino** - *Back-End do projeto* - [Maurício Marcelino](https://github.com/marcostwelve)


## 📄 Licença

Esse projeto está sob a licença (MIT) - acesse os detalhes [LICENSE.md](https://opensource.org/license/mit/).




## 💡 Expressões de gratidão

* Agradeço todos por verificarem o meu projeto. Esotu aberto a sugestões de melhorias e evolução do projeto.
* [Meu linkedin](https://www.linkedin.com/in/mauricio-marcelino/)
