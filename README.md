<p align="center">
   <img src=".github/passarinhoAAFolou.png" width="424" height="296"/>
</p>

<br/>

> #### Peep is a social network freely inspired by Twitter, currently under development.

<br/>
My goal with this project, which will be the biggest and best designed in my portfolio, is to improve my skills as a developer. With it I will get to know new technologies, standards and architectures, and delve into system design of distributed systems.
<br/>

### Back-end services (under development)

| Service                             | Description                                  |
| ----------------------------------- | -------------------------------------------- |
| [Wings](source/Peep.Wings)          | Auth + Social Graph Service                  |
| [Parrot](source/Peep.Parrot)        | Parrot service (new posts, likes, reposts)   |
| Soon                                | User Timeline service                        |
| Soon                                | Home Timeline service                        |
| Soon                                | Search service                               |
| Soon                                | Fanout service                               |

## Some Twitter architecture references:

[Twitter System Architecture](https://medium.com/interviewnoodle/twitter-system-architecture-8dafce16aec4)

<br/>

[System Design: Twitter](https://dev.to/karanpratapsingh/system-design-twitter-865)

<br/>

Better docs soon!

### Monolithic front-end

On hold - POC started, I just copied Twitter design and did some React state management sh*t.

| App                                                         |  Description              |
| ----------------------------------------------------------- | ------------------------- |
| [Peep for Web](source/web)          | React SPA (Next.js)                               | 


## How to run the project

### Peep for Web

First, install the dependencies:

```bash
npm install
# or
yarn install
```

Then, run the development server:

```bash
npm run dev
# or
yarn dev
```

Open [http://localhost:3000](http://localhost:3000) with your browser to see the result.

### Back-end services

Just run the APIs, from Visual Studio 2022 (default option - IIS Express).

If the projects are running in other way or in other IDE/editor (VS Code for example),
the urls may change. In that case, change the values from the Next.js application's 
.env file to the corresponding urls and be happy :)

## License 

- [MIT](https://choosealicense.com/licenses/mit/)

<br/>

<div align="center">
   <img alt="Csharp" src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" />
   <img alt="dotnet" src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
   <img alt="TypeScript" src="https://img.shields.io/badge/TypeScript-007ACC?style=for-the-badge&logo=typescript&logoColor=white" />
</div>
