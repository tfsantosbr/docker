# Instruções

## Teste calculadora.api

http://localhost:2001/api/calculos/somar/1/1

http://localhost:2001/api/calculos/subtrair/1/1

## Teste cep.api

http://localhost:2002/api/cep/123456

http://localhost:2002/api/cep/654321

## Rodando as APIs no Docker

Comandos para compilar/atualizar as APIs em imagens de containers

```bash
docker build -t taigobrasil/calculadora.api .
docker build -t taigobrasil/cep.api .
```

Comandos para executar os containers com as imagens das APIs

```bash
docker run --rm -it -d -p 2001:80 --name calculadora.api taigobrasil/calculadora.api
docker run --rm -it -d -p 2002:80 --name cep.api taigobrasil/cep.api
```