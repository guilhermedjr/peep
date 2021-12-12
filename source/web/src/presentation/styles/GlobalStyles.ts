import { createGlobalStyle } from 'styled-components'

export default createGlobalStyle`
  :root {
    --primary: #000;
    --primary-light: rgba(54, 54, 54, 0.15);
    --secondary: #15181C;
    --search: #202327;
    --white: #D9D9D9;
    --gray: #7A7A7A;
    --outline: #2F3336;
    --repeep: #00C06B;
    --repeep-light: rgb(0, 192, 107, 0.5);
    --like: #E8265E;
    --like-light: rgb(232, 38, 94);
    --peep: #8B008B;
    --peep-dark-hover: #4B0082;
    --peep-light-hover: rgba(75, 0, 130, 0.2);
  }
  * {
    margin: 0; 
    padding: 0;
    box-sizing: border-box;
    color: var(--white);
  }
  html, body, #root {
    max-height: 100vh;
    max-width: 100vw;

    height: 100%;
    width: 100%;
  }
  *, button, input {
    border: 0;
    background: none;
    font-family: -apple-system, system-ui, sans-serif;
  }
  html {
    background: var(--primary);
  }
  @font-face {
    font-family: 'Segoe UI';
    src: url('/fonts/segoe-ui.otf') format('otf');
  }
`

