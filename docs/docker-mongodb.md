# Docker MongoDb Commands

Guia de comandos para executar o banco de dados **MongoDB** em docker

## Comandos

```bash
# Baixando a imagem
docker pull mongo

# Executando em um container
docker run --name mongodb -p 27017:27017 -d mongo
```