# Docker Commands

## System

```bash
# Limpa todas imagens, containers, volumes e networks não associadas a um container
docker system prune

# Limpa todas imagens, containers, volumes e networks 
docker system prune -a
```

## Containers

```bash
# Visualiza os containers que estão em execução
docker ps

# Visualiza os containers que estão em execução, junto com os container parados
docker ps -a

# Para a execução de um container
docker stop <container ID ou container name>

# Remove um container
docker rm <container ID ou container name>
```

## Images

```bash
# Baixar uma imagem
docker pull <imagem>

# Compila uma nova imagem de container baseada em um Dockerfile
cd <diretório com o dockerfile>
docker build -t <image-name> .

# Executa uma imagem 
docker run --rm -it -d -p <porta>:80 --name <nome do container> <nome da imagem>
```

## Dicas
- Para acessar um container através de outro container ao invés utiliza-se `host.docker.internal` ao invés de `localhost`
