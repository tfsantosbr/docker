# Docker
Repositório com exemplos de utilização do docker e comando mais comuns utilizados pelo Docker CLI.



### Comandos do Docker

Visualiza os containers que estão em execução

```bash
docker ps
```

Visualiza os containers que estão em execução, junto com os container parados

```bash
docker ps -a
```

Compila uma nova imagem de container baseada em um Dockerfile

```bash
cd <diretório com o dockerfile>
docker build -t <image-name> .
```

Executa uma imagem 

```bash
docker run --rm -it -d -p <porta>:80 --name <nome do container> <nome da imagem>
```

Para a execução de um container

```bash
docker stop <container ID ou container name>
```

Remove um container

```bash
docker rm <container ID ou container name>
```

Remove todos os containers parados:

```bash
docker ps -q |xargs docker rm
```

Remove todas as imagens que não estão sendo usadas:

```bash
docker images -q |xargs docker rmi
```