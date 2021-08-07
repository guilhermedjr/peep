import { createStore, combineReducers } from 'redux'

const INITIAL_STATE = []

const reducers = combineReducers({
  prop1: function (state = INITIAL_STATE, action) {
    return {
      exemplo: 'ok',
    }
  },
  prop2: function (state = INITIAL_STATE, action) {
    return {
      exemplo: 'ok, de novo',
    }
  },
})

const store = createStore(reducers)

export default store
