<p align="center">
   <img src=".github/passarinhoAAFolou.png" width="424" height="296"/>
</p>

<br/>

> #### Peep is a social network freely inspired by Twitter.

<br/>
My goal with this project, which will be the biggest and best designed in my portfolio, is to improve my skills as a developer. With it I will get to know new technologies, standards and architectures, explore the best possibilities for each part of the application and acquire a more mature and embracing view of the software development process.
<br/>

| App                                                         |  Description              |
| ----------------------------------------------------------- | ------------------------- |
| [Peep for Web](source/web)          | React SPA (Next.js)                               | 
| [Wings](source/Peep.Wings)          | .NET Auth Server                                  |
| [Parrot](source/Peep.Parrot)        | .NET Main Server                                  |

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

### Wings and Parrot

Just run the APIs, from Visual Studio 2022 (default option - IIS Express).

If the projects are running in other way or in other IDE/editor (VS Code for example),
the urls may change. In that case, change the values from the Next.js application's 
.env file to the corresponding urls and be happy :)

### Databases (SQL Server and Azure CosmosDB)

The development databases are hosted on Microsoft Azure, as well as the production databases.
Thus, no additional configuration is required.

## Hosting

| App                                                         |  Description              |
| ----------------------------------------------------------- | ------------------------- |
| Peep Wings                                                  | Azure (Free)              |
| Peep Parrot                                                 | Azure (Free)              |
| SQL Server                                                  | Azure (12 free months, max 250 GB) |
| Azure Cosmos DB (SQL API)                                   | Azure (Free - limited transfer rate) |
| Next.js WebApp                                              | Vercel (Free) |

## License 

- [MIT](https://choosealicense.com/licenses/mit/)

<br/>

<div align="center">
   <img alt="Csharp" src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" />
   <img alt="dotnet" src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
   <img alt="TypeScript" src="https://img.shields.io/badge/TypeScript-007ACC?style=for-the-badge&logo=typescript&logoColor=white" />
   <img alt="React" src="https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB" />
   <img alt="Nextjs" src="https://img.shields.io/badge/next.js-000000?style=for-the-badge&logo=nextdotjs&logoColor=white"/>
   <img alt="SQL Server" src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white" />
   <img alt="Azure" src="https://img.shields.io/badge/microsoft%20azure-0089D6?style=for-the-badge&logo=microsoft-azure&logoColor=white" />
   <img alt="Vercel" src="https://img.shields.io/badge/Vercel-000000?style=for-the-badge&logo=vercel&logoColor=white" />
</div>
