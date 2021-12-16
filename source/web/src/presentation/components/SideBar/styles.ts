import styled from 'styled-components'

import { Search } from '../../styles/icons'

export const Container = styled.div`
  display: none;

  @media (min-width: 1000px) {
    display: flex;
    flex-direction: column;
    align-items: center;

    //width: min(399px, 100%);
    width: 399px;
  }
`

export const SearchWrapper = styled.div`
  //padding: 10px 24px;
  padding-left: 24px;
  padding-right: 24px;
  padding-top: 10px;
  padding-bottom: 10px;
  width: min(399px, 100%);
  box-shadow: none;
  position: fixed;
  top: 0;
  z-index: 2;
  max-height: 57px;

  background: green;
`

export const SearchInput = styled.input`
  width: 100%;
  height: 39px;
  font-size: 14px;
  padding: 0 10px 0 52px;
  border-radius: 19.5px;
  background: var(--search);

  &::placeholder {
    color: var(--gray);
  }

  ~ svg {
    position: relative;
    top: -33px;
    left: 15px;
    z-index: 1;

    transition: 100ms ease-in-out;
  }

  outline: 0;

  &:focus {
    border: 1px solid var(--peep);

    ~ svg {
      fill: var(--peep);
    }
  }

`

export const SearchIcon = styled(Search)`
  width: 27px;
  height: 27px;

  fill: var(--gray);
`

export const Body = styled.div`
  display: flex;
  flex-direction: column;
  padding: 57px 24px 200px;
  margin-top: 3px;

  > div + div {
    margin-top: 15px;
  }
`