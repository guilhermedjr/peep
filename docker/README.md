### Run all the docker containers with Docker Compose

```
docker-compose up
```

### How to stop running

```
docker-compose down
```

### Redsmin (Redis Online GUI) tips

Redsmin is being used in development environment for managing Parrot's Redis database, but there are several other good options, some free or with trial period. 
That said, if you also choose Redsmin, here are some tips: 

#### How to install Redsmin Proxy (for localhost databases)

<ul>
<li>Debian/Ubuntu/MacOS</li>

```
npm install redsmin@latest -g && REDSMIN_KEY=PROXY_CONNECTION_KEY redsmin
```

<li>Windows (CMD)</li>

```
npm install redsmin --global
set REDSMIN_KEY=PROXY_CONNECTION_KEY
redsmin
```

<li>Windows (Powershell)</li>

This is a complete example that fits our Redis server created on "docker-compose up". We need to inform the port
and the password to be able to make the connection.

```
npm install redsmin --global
$env:REDIS_URI="redis://localhost:6379"
$env:REDIS_AUTH="redis-docker"
$env:REDSMIN_KEY="PROXY_CONNECTION_KEY"
redsmin
```

<ul>

