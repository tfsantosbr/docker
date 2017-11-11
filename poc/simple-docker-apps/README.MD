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

## Enviando as APIs para o Docker Hub

```bash
docker push taigobrasil/calculadora.api
docker push taigobrasil/cep.api
```

## Executando o RabbitMQ

```bash
docker run -d -h rabbit --name rabbit -p "4369:4369" -p "5672:5672" -p "15672:15672" -p "25672:25672" -p "35197:35197" -e "RABBITMQ_USE_LONGNAME=true" -e "RABBITMQ_LOGS=/var/log/rabbitmq/rabbit.log" -v /data:/var/lib/rabbitmq -v /data/logs:/var/log/rabbitmq rabbitmq:management
```