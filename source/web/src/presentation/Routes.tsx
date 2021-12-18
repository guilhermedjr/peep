import React from 'react'
import { Router, Route, Switch, Redirect } from 'react-router-dom'
import { createBrowserHistory, createMemoryHistory  } from 'history'
import Main from './components/Main'
//import { ExpandedPeep } from './components/ExpandedPeep'

const memoryHistory = createMemoryHistory();

const Routes = () => {
  return (
    <Router history={memoryHistory}>
      <Switch>
        <Route path="/home/:userId" component={Main} />
        {/* <Route path="/:peepUser/status/:peepId" component={ExpandedPeep} /> */}
      </Switch>
    </Router>
  )
}

export default Routes