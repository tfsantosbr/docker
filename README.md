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
# -a -> Retorna os containers que foram parados
```

Compila uma nova imagem de container baseada em um Dockerfile

```bash
cd <diretório com o dockerfile>
docker build -t <image-name> .
# -t ?
```

Executa uma imagem 

```bash
docker run --rm -it -d -p <porta>:80 --name <nome do container> <nome da imagem>
# --rm ?
# -it ?
# - p -> Especifica a porta em que a aplicação será rodada
# --name -> Da um nome ao container
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
docker stop $(docker ps -a -q) && docker rm $(docker ps -a -q) #bash
docker ps -q |xargs docker rm
# -q ?
```

Remove todas as imagens que não estão sendo usadas:

```bash
docker images -q |xargs docker rmi
# -q ?
```
Executando containers pelo docker-compose

```bash
cd <diretorio onde contém o arquivo docker-compose.yml>
docker-compose up -d --build
# -d usado para rodar em background
# -- buiild -> compila novas versões das imagens antes de executá-las
```

Parando e removendo os containers pelo docker-compose

```bash
docker-compose down
```

Listar os volumes criados

```bash
docker volume ls
```

Remover todos os volumes não utilizados

```bash
docker volume prune
```

