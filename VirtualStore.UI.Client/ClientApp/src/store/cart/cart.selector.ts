import { Cart } from "../../models/cart/cart.model";
import { store } from "../..";

class CartSelector {
  getCart = (): Cart => {
    const state = store.getState();

    return state.cart.cart;
  };
}

export default new CartSelector();
