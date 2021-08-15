import styled from 'styled-components'

type ButtonProps = {
  outlined?: boolean
}

export default styled.button<ButtonProps>`
  background: ${props => props.outlined ? 'transparent' : 'var(--peep)'};
  color: ${props => props.outlined ? 'var(--peep)' : 'var(--white)'};
  border: ${props => props.outlined ? '1px solid var(--peep)' : 'none'};

  padding: 16px;
  border-radius: 25px;

  font-weight: bold;
  font-size: 15px;

  cursor: pointer;
  outline: 0;

  &:hover {
    background: ${props => 
                  props.outlined 
                    ? 'var(--peep-light-hover)' 
                    : 'var(--peep-dark-hover)'}
  }
`