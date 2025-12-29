# 🏪 LojaConsole - Sistema de Gestão em Memória

> Projeto desenvolvido durante o **Módulo 2: O Console de Gestão** do curso de Desenvolvimento Backend.

## 💻 Sobre o Projeto

O **LojaConsole** é uma aplicação CLI (Command Line Interface) desenvolvida em **C#** para simular o gerenciamento de estoque de uma loja. 

O objetivo principal deste projeto foi consolidar a lógica de programação e entender como os dados são manipulados na memória RAM antes de serem persistidos em um banco de dados real.

**⚠️ Característica Didática:** Este sistema opera 100% em memória (RAM). Isso significa que, ao fechar a aplicação, os dados são perdidos propositalmente para evidenciar a necessidade de persistência de dados (que será abordada no próximo módulo com SQL e Entity Framework).

## ⚙️ Funcionalidades

- [x] **Cadastrar Produtos:** Adiciona novos itens à lista em memória com validação de preço (não aceita valores negativos ou zero).
- [x] **Listar Produtos:** Exibe todos os produtos cadastrados com formatação de moeda.
- [x] **Remover Produtos:** Localiza um item pelo ID e o remove da lista.
- [x] **Menu Interativo:** Navegação via terminal utilizando laços de repetição.

## 🚀 Tecnologias e Conceitos Aplicados

Durante o desenvolvimento deste projeto, foram aplicados os seguintes conceitos:

* **Linguagem C#:**
    * Manipulação de Variáveis e Tipos (`int`, `string`, `decimal`).
    * Estruturas Condicionais (`if/else`, `switch case`).
    * Laços de Repetição (`while`, `foreach`).
    * Interpolação de Strings.
* **Programação Orientada a Objetos (POO):**
    * Criação de Classes e Objetos (Molde `Produto`).
    * Propriedades e Encapsulamento.
* **Estrutura de Dados:**
    * Uso de Coleções Genéricas (`List<T>`).
    * Expressões Lambda para busca (`Find`) e remoção de itens.
* **Versionamento:**
    * Git (Init, Add, Commit).
    * GitHub (Remote, Push).

## 📦 Como rodar o projeto

Pré-requisitos: Tenha o [.NET SDK](https://dotnet.microsoft.com/download) instalado.

```bash
# Clone este repositório
$ git clone https://github.com/GabrielCezario1/LojaConsole.git

# Acesse a pasta do projeto
$ cd LojaConsole

# Execute a aplicação
$ dotnet run
```

## 🔜 Próximos Passos (Roadmap)
Este projeto faz parte de uma trilha de aprendizado. As próximas evoluções incluem:

[ ] Persistência de Dados: Conectar o sistema ao MySQL.

[ ] ORM: Implementar Entity Framework Core.

[ ] API: Transformar este console em uma Web API RESTful.

Desenvolvido por Gabriel Vieira de Souza 🚀
