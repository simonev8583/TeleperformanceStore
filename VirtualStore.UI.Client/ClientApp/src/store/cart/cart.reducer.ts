import { CartActionTypes } from "./cart.types";

const initialState = {
  cart: null,
};

export default (state = initialState, action: any) => {
  switch (action.type) {
    case CartActionTypes.UPDATE_CART:
    case CartActionTypes.GET_CART:
      return {
        ...state,
        cart: action.payload,
      };
    default:
      return initialState;
  }
};
