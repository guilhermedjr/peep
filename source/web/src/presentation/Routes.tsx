import React from 'react'

import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom'
import Main from './components/Main'
import { ExpandedPeep } from './components/ExpandedPeep'

const Routes = () => {
  return (
    <BrowserRouter>
      <Switch>
        <Route path="/home" component={Main} />
        <Route path="/:peepUser/status/:peepId" component={ExpandedPeep} />
      </Switch>
    </BrowserRouter>
  )
}

export default Routes