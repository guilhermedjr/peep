import styled from 'styled-components'

type ContainerProps = {
  visible: boolean 
}

export default styled.div<ContainerProps>`
  position: absolute;
  top: 0;

  display: flex;

  width: 100vw;
  height: 100vh;

  background-color: rgba(91, 112, 131, 0.4);

  justify-content: center; 

  z-index: 1000;
`