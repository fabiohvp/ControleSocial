# ControleSocial

This project is a test-case on the backend for my framework WorkflowApi.Core and on the frontend for https://cidades.tce.es.gov.br using svelte.

**PS1** Trying to setup docker but it is not working yet.

**To run this project:**
1. you need a sql server on port 1440 with two databases "ControleSocial" and "DWControleSocial" with a password (it is configured to use "ControleSocial!" but you can change the port and password on Server/src/appsettings.json)
2. clone
3. go to Client and run "yarn install"
4. go to Server/src and run "dotnet restore", "dotnet build" and "dotnet ef database update"
5. to run client you can eiter go to root folder and run "yarn dev" or you can go to Client folder and run one of the scripts from package.json (this may take a while to run but after is running the hot reload is super fast)
6. to run server you can launch debug (.NET Core Launch (console)) or you can go to Server/src folder and run "dotnet run"
7. create an account direct on database inserting inside ControleSocial.Usuario (Nome = name, Senha = password (plain text), Roles for now only "Admin")
8. download the files from https://github.com/fabiohvp/ControleSocial-Database (for each year you need Receita/Despesa/PrestacaoConta)
9. open http://localhost:5000/admin and authenticate
10. upload the files (upload 2020 first because it is smaller and faster)
11. leave the admin interface and navigate to Receitas or Despesas (for now the year dropdown is fixed with 2017/2018/2019/2020 but if you have not uploaded the respective year don't select it, it will thrown a js error and you will need to reload the page)
