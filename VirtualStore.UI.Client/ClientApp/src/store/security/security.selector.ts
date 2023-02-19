import { store } from "../..";

class SecuritySelector {
  getSessionStatus = (): boolean => {
    const state = store.getState();

    return state.security.inSession;
  };

  isRegister = (): boolean => {
    const state = store.getState();

    return state.security.personRegister;
  };
}

export default new SecuritySelector();
