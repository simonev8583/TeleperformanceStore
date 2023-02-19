import { Cart } from "../../models/cart/cart.model";
import { CartActionTypes } from "./cart.types";
import cartService from "./cart.service";
import { Dispatch } from "redux";

class CartAction {
  getCartAction = () => async (dispatch: Dispatch) => {
    const promise = cartService.getCart();

    try {
      const result = await Promise.resolve(promise);

      dispatch({ type: CartActionTypes.GET_CART, payload: result });
    } catch (error) {
      console.log(error);
      console.log("dispatch error");
    }
  };

  updateCartAction = (cart: Cart) => async (dispatch: Dispatch) => {
    const promise = cartService.updateCart(cart);

    try {
      const result = await Promise.resolve(promise);

      dispatch({ type: CartActionTypes.UPDATE_CART, payload: result });
    } catch (error) {
      console.log(error);
      console.log("dispatch error");
    }
  };
}

export default new CartAction();
