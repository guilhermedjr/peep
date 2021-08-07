# Contributing to Peep

First off, thanks for taking an interest in contributing to this project!

The following is a set of guidelines that may help you to contribute to Peep in the best way.
These are not rules, but issues/pull requests that follow the recommendations have a greater
chance of being reviewed and merged, and in a faster time, in addition to being more likely
to receive contributions from other interested developers.

In resume, these guidelines facilitate the communication between the contributors and the repository owner(s),
and between the contributors themselves. By choosing to sign this "contract" with the community and follow its
suggestions, you will be contributing in a more relevant way with this project and with the growth of everyone involved in it.

##### List of guidelines

- [Contribuing](#how-to-contribute)
- [Styleguides](#styleguides)

## How to contribute

### Suggesting features

Know that feature you wanted to see on Twitter? Or one that already exists but could be improved? 
You can open a "Discussion" proposing functionalities that don't exist on Twitter. 
In the case of small changes to existing features on the social network and already implemented here on Peep, 
pull requests can be made.

Coming soon: guidelines for **issues** and **pull requests**

## Styleguides

Styleguides set standards for code writing and indentation, so the project can grow and receive contributions without losing its readability or becoming difficult to maintain.

> "Any fool can write code that a computer can understand. Good programmers write code that humans can understand.“ - Martin Fowler

- [TypeScript](#typeScript-styleguide)
- [C#](#c#-styleguide)

### TypeScript Styleguide

All TypeScript code is automatically linted with [Prettier](https://prettier.io/). Two-space indentation, no semicolon. No code gut.

- Type everything: no "any"
- Avoid creating files with .js or .jsx extensions: in this house we use and abuse TypeScript
- Never use 'var': just 'let' or 'const'
- Use functional components instead class components

> "Look, don't misjudge me... but anyone who still uses JavaScript instead TypeScript deserves a good spanking" - Lil Peep

- [Imports/Exports](#imports-and-exports)
- [Types/Interfaces](#types-or-interfaces)
- [Naming](#naming-on-ts)

#### Imports and Exports

Inline exports with expressions whenever possible

```typescript
// Use this:
export default class ClassName {

}

// Instead of:
class ClassName {

}
export default ClassName
```

#### Types or Interfaces

Type declarations instead of interface declarations whenever possible

```typescript
// Use this:
type User = {
  Id: string
  Name: string
  Username: string
}

// Instead of:
interface User {
  Id: string
  Name: string
  Username: string
}
```

Only create interfaces to establish contracts that must be followed by implementations of those interfaces,
as in the example:

```typescript
interface IHttpClient {
  httpGet<T>(url: string): Promise<T>
}

export class AxiosHttpClient implements IHttpClient {
  public async httpGet<T>(url: string): Promise<T> {
    // some method implementation
  }
}

export class FetchApiHttpClient implements IHttpClient {
  public async httpGet<T>(url: string): Promise<T> {
    // some method implementation
  }
}
```

#### Naming on TS

- 'Interfaces' must start with the capital letter I. 'Types' must not, after all they are types and not interfaces
- 'Enums' must start with the capital letter E

- UpperCamelCase:

  - Classes
  - Types
  - Enums
  - Interfaces
  - Components

- lowerCamelCase:

  - Variables
  - Class methods
  - Functions (except for Components)

- Preferably, the names of the entity types (including enums) must be the same as the names defined in the backend

### C# Styleguide

- [Naming](#naming-on-c#)

#### Naming on C#

- Data transfer objects (DTOs) must always end with 'Dto'. Naming such as 'DtoEditPeep' or 'EditPeepDTO' breaks the convention

- lowerCamelCase: variables. For the rest, capitalized first letter
