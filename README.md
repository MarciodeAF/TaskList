# 🚀 {TaskList - Project .NET Core - API REST no DOCKER}

Este repositório contém um projeto desenvolvido utilizando .NETCORE, Docker e imagem SQLServer. A seguir, você encontrará um guia passo a passo interativo para abrir o projeto em seu ambiente local.

## Pré-requisitos

Antes de começar, verifique se você possui as seguintes ferramentas instaladas em sua máquina:

✅ Docker
✅ Docker Compose
✅ Visual Studio 2019
✅ DBeaver

## Passo 1️⃣: Clonar o repositório

Comece clonando este repositório para sua máquina local. Para clonar o repositório, clique no botão "Clone" acima ou execute o seguinte comando no terminal:

```bash
git clone [https://github.com/MarciodeAF/TaskList.git]
```

Isso criará uma cópia local do repositório em seu ambiente.

## Passo 2️⃣: Iniciar os contêineres Docker

Navegue até o diretório raiz do projeto e execute o seguinte comando para iniciar os contêineres Docker:

```bash
docker-compose up -d
```

🐳 Isso iniciará os contêineres necessários para o projeto, incluindo o servidor SQLServer.

## Passo 3️⃣: Acessar pagina inicial 

Após iniciar os contêineres, você pode acessar o servidor através do seu navegador no endereço [http://localhost:32033/api/tasks].

## Passo 4️⃣: Acessar o Banco de Dados

Você também pode acessar o banco de dados usando o DBeaver
![image](https://github.com/user-attachments/assets/d118d71b-c5c6-4584-89e4-33a8c17c3347)

## Passo 5️⃣: Modificar o projeto

Agora que você tem o projeto em execução, é possível fazer modificações no código conforme necessário. Sinta-se à vontade para explorar e adaptar o projeto de acordo com suas necessidades.

## Passo 6️⃣: Publicar suas modificações

Se desejar publicar suas modificações em um repositório remoto no GitHub, siga estes passos:

1️⃣ Crie um novo repositório vazio no GitHub.
2️⃣ No terminal, navegue até o diretório raiz do projeto.
3️⃣ Execute os seguintes comandos:

```bash
git remote set-url origin https://github.com/seu-usuario/nome-do-novo-repositorio.git
git add .
git commit -m "Adicionar minhas modificações"
git push -u origin master
```

Isso configurará o repositório remoto e enviará suas modificações para lá.

🎉 Espero que este guia passo a passo tenha sido útil para você abrir e explorar o projeto .Net Core, Docker e SQLServer. Sinta-se à vontade para adaptar as instruções de acordo com a estrutura do seu projeto específico. Divirta-se codificando! 😄
