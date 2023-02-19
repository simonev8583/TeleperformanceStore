import { applyMiddleware, combineReducers, compose, createStore } from "redux";
import thunk from "redux-thunk";
import { connectRouter, routerMiddleware } from "connected-react-router";
import { History } from "history";
import { ApplicationState, reducers } from "./";
import { STORAGE_KEY } from "./types";

export default function configureStore(
  history: History,
  initialState?: ApplicationState
) {
  const middleware = [thunk, routerMiddleware(history)];

  const rootReducer = combineReducers({
    ...reducers,
    router: connectRouter(history),
  });

  const enhancers = [];
  const windowIfDefined =
    typeof window === "undefined" ? null : (window as any); // eslint-disable-line @typescript-eslint/no-explicit-any
  if (windowIfDefined && windowIfDefined.__REDUX_DEVTOOLS_EXTENSION__) {
    enhancers.push(windowIfDefined.__REDUX_DEVTOOLS_EXTENSION__());
  }

  const store = createStore(
    rootReducer,
    persistedState,
    compose(applyMiddleware(...middleware), ...enhancers)
  );

  store.subscribe(() => {
    saveState({
      security: store.getState().security,
    });
  });

  return store;
}

export const persistedState = (() => {
  try {
    const rawState = localStorage.getItem(STORAGE_KEY);
    if (rawState === null) return undefined;

    return JSON.parse(rawState);
  } catch (err) {
    return undefined;
  }
})();

export const saveState = (state: any) => {
  try {
    let stateFilter = JSON.parse(JSON.stringify(state));
    const rawState = JSON.stringify(stateFilter);
    localStorage.setItem(STORAGE_KEY, rawState);
  } catch (err) {
    // Ignore write errors.
  }
};
