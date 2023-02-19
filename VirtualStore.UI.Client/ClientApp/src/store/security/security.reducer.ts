import { SecurityActionTypes } from "./security.types";

const initialState = {
  inSession: false,
  token: null,
  personRegister: false,
};

export default (state = initialState, action: any) => {
  switch (action.type) {
    case SecurityActionTypes.SIGN_IN:
      return {
        ...state,
        inSession: !!action.payload.token,
        token: action.payload.token,
      };

    case SecurityActionTypes.SIGN_UP:
      return {
        ...state,
        personRegister: !!action.payload,
      };

    default:
      return state;
  }
};
